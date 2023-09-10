﻿using DA_Lab_1.DataConverters.Base;
using DA_Lab_1.DTO.Base;
using DA_Lab_1.Extentions;
using System;
using System.Collections.Generic;
using System.Data;

namespace DA_Lab_1.Specifics.DataHandlers
{
    internal abstract class DataConverter<T1, T2> : IDataConverter where T1 : IData where T2 : IData
    {
        public Type FromType => typeof(T1);

        public Type ToType => typeof(T2);

        public abstract Type? ParametersType { get; }

        public List<IData> Handle(List<IData> data, IDataConverterParameters? parameters)
        {
            return Handle(data.ToTemplateDataList<T1>(), parameters).ToGeneralDataList();
        }

        protected abstract List<T2> Handle(List<T1> data, IDataConverterParameters? parameters);
    }
}

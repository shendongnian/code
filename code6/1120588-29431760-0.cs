    var newValues = MetarDecoder.Decode(telegram)
                .OfType<MeteoParameter<decimal>>()
                .Select(param => { 
                       var parameter = MeteoParameterFactory.Create(param.ParameterId, param.DateTime.ToLocalTime(), param.Status, param.Value);
                       parameter.Info = param.Info;
                       return parameter;
                 }).ToList();

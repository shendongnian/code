    var val = MetarDecoder
                .Decode(telegram)
                .OfType<MeteoParameter<decimal>>()
                .ToList()
                .ForEach(param => 
                {
                    var parameter = MeteoParameterFactory.Create(param.ParameterId, param.DateTime.ToLocalTime(), param.Status, param.Value);
                    parameter.Info = param.Info;
                    newValues.Add(parameter);
                });

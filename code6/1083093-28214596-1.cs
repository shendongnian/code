            private static void InitializeFormatters()
            {
                GlobalConfiguration.Configuration.Formatters.Clear();
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                GlobalConfiguration.Configuration.Formatters.Add(formatter);
                GlobalConfiguration.Configuration.Formatters.Add(new PlainTextFormatter());
            }

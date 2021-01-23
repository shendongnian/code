        private void ConfigureWebApi(HttpConfiguration config)
        {
            //..
            foreach (var jsonFormatter in config.Formatters.OfType<JsonMediaTypeFormatter>())
            {
                jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            var singlejsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            singlejsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void SetNewJsonFormatterWithCustomContractResolver(bool returnMVFormat)
        {
            //Create a new JsonMediaTypeFormatter
            var newJsonFormatter = new JsonMediaTypeFormatter();
            newJsonFormatter.SerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DynamicContractResolver(returnMVFormat)
            };
            GlobalConfiguration.Configuration.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(newJsonFormatter));
        }

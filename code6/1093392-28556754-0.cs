    internal static class ViewHelpers
    {
        public static JsonSerializerSettings CamelCase
        {
            get
            {
                return new JsonSerializerSettings {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
            }
        }
    }

    namespace ValueProviderSample
    {
        public static class MyValuesContainer
        {
            public static readonly string[] Values = { "one", "two", "three" };
        }
    
        public class MyMethodContainer
        {
            public string MyMethod([ValueProvider("ValueProviderSample.MyValuesContainer.Values")]
                                   string parameter)
            {
                return string.Empty;
            }
        }
    }

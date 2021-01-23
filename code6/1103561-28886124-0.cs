    class Program
        {
            public static void Main(string[] args)
            {
                var helper = new ConfigurationHelper<BestTestConfiguration>(new BestTestConfiguration()
                {
                    Objects = new List<string>()
                    {
                        "testing 1",
                        "testing 2"
                    }
                });
                var item = helper.GetEnumerator();
                Console.ReadLine();
            }
    
    
        }
    
        public class ConfigurationHelper<T> : IEnumerable<object[]> where T : BestTestConfiguration
        {
            public T Configuration;
    
            public ConfigurationHelper(T configuration)
            {
                Configuration = configuration;
            }
    
            public IEnumerator<object[]> GetEnumerator()
            {
                ParameterExpression element = Expression.Parameter(typeof(T), "element");
                //use reflection to check the property that's a generic list
                var items = new List<object[]>();
    
                foreach (PropertyInfo property in Configuration.GetType().GetProperties().Where(x => x.PropertyType.IsGenericType))
                {
                    var valueOfProperty = Configuration.GetType().GetProperty(property.Name).GetValue(Configuration, null);
                    items.Add(new object[] {valueOfProperty});
                }
    
                return items.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    
        public class BestTestConfiguration
        {
            public List<string> Objects { get; set; }
        }

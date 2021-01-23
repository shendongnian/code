        static void Main(string[] args)
        {
            WithIndexer indexer = new WithIndexer();
            var type = indexer.GetType();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                if (!prop.Name.StartsWith("Item", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                var indexProperty = prop;
                Console.WriteLine("{0}", indexProperty);
                if (indexProperty.GetGetMethod() != null)
                {
                    var getMethod = indexProperty.GetGetMethod();
                    var parameters = getMethod.GetParameters();
                    IList<object> newParams = new List<object>();
                    foreach (var par in parameters)
                    {
                        if (par.ParameterType.Equals(typeof(string)))
                        {
                            newParams.Add("key");
                            continue;
                        }
                        if (par.ParameterType.Equals(typeof(int)))
                        {
                            newParams.Add(new Random().Next(50));
                            continue;
                        }
                        newParams.Add(null);
                    }
                    var result1 = getMethod.Invoke(indexer, newParams.ToArray());
                    Console.WriteLine("Result from {0} = {1}", string.Join(",", newParams), result1);
                }
            }
            Console.ReadLine();
        }
    }

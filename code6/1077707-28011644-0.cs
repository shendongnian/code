    public static class Extensions
    {
        public static void PrintAllProperties<T>(T type)
        {
            var t = type.GetType();
            var properties = t.GetProperties();
            Console.WriteLine("Listing all properties for type {0}", t);
            foreach (var prop in properties)
            {
                Console.WriteLine("{0} is of type: {1}", prop.Name, prop.PropertyType);
            }
        }
    }

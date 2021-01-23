    public static class DynamicExtension
    {
        public static void GetDynamicProperties(this Type source)
        {
            source.GetProperties()
                  .Where(x => x.GetCustomAttributes().OfType<DynamicAttribute>().Any())
                  .ToList()
                  .ForEach(x => Console.WriteLine(x.Name));
        }
    }

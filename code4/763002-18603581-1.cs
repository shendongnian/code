    public static class TypeExtensions
    {
        public static void BrowseProperties(this Type type)
        {
            var h1 = typeof(Car).GetProperties().ToList();            
            var h2 = h1.Where(x => x.PropertyType.GetCustomAttributes(true).OfType<BrowsableAttribute>().Any());                       
            
            h2.ToList().ForEach(x => h1.AddRange(x.PropertyType.GetProperties()));
            h1.ForEach(x => Console.WriteLine(x.Name));
        }
    }

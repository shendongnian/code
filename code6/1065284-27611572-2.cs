    public static void Main(string[] args)
    {
        // Uncomment to get the names in Portuguese
        //Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt-PT");
        Type type = typeof(User);
        var propertyList = type.GetProperties()
            .Where(prop => prop.PropertyType == typeof(string))
            .Select(prop => GetPropertyName(prop)).ToList();
        foreach (string propertyName in propertyList)
        {
            Console.WriteLine(propertyName);
        }
    }

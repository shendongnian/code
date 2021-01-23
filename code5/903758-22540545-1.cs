    var propertiesWithAttribute = typeof(Entity).GetProperties()
        // use projection to get properties with their attributes - 
        .Select(pi => new { Property = pi, Attribute = pi.GetCustomAttributes(typeof(MyAttribute), true).FirstOrDefault() as MyAttribute})
        // filter only properties with attributes
        .Where(x => x.Attribute != null)
        .ToList();
    
    foreach (Entity entity in collection)
    {
        foreach (var pa in propertiesWithAttribute)
        {
            object value = pa.Property.GetValue(entity, null);
            Console.WriteLine("PropertyName: {0}, PropertyValue: {1}, AttributeName: {2}", pa.Property.Name, value, pa.Attribute.GetType().Name);
        }
    }
    

    EntityBase entity = new Employee();
    var properties = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
    foreach (var  property in properties)
    {
        Console.WriteLine(string.Format("Name = {0}, Value = {1}",
            property.Name,
            property.GetValue(entity)));
    }

    foreach (var prop in data[0].GetType().GetProperties())
    {
        if (prop.GetValue(data[0], null) != null)
            Console.WriteLine("{0}, Type {1}", prop.Name, prop.PropertyType);
    }

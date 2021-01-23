    Type type = person1.GetType();
    PropertyInfo[] properties = type.GetProperties();
    
    foreach (PropertyInfo property in properties)
    {
        Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(person1, null));
    }

    foreach (var propertyInfo in myClass.GetType().GetProperties())
    {
        var name = propertyInfo.Name;
        var value = propertyInfo.GetValue(myClass);
                
        // do stuff
        Console.WriteLine("Value of {0} is {1}", name, value ?? "null");
    }

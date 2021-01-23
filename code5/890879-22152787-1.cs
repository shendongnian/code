    var myClass = new MyClass
    {
        Id = 1,
        Name = "My Name",
        Subordinates = new List<int> { 2, 5, 8 }
    };
    
    var props = myClass.GetType().GetProperties();
    foreach (var info in props)
    {
        var type = info.PropertyType;
    
        if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)))
        {
            foreach (var listitem in info.GetValue(myClass, null) as IEnumerable)
            {
                Console.WriteLine("Item: " + listitem.ToString());
            }
    
            continue;
        }
        Console.WriteLine(info.GetValue(myClass, null));
    }

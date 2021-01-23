        var collection = new List<object> { 1, 2.2, "string", 'c' };
        var myVariable = collection.Select(item => item.GetType());
        foreach(var m in myVariable)
        {
            Console.WriteLine(m.FullName);
        }

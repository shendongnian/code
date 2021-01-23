    foreach (var prop in typeof(Class2).GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
        foreach (var obj in mainClass.listObj1)
        {
            foreach (var innerClass in obj.dictObj2.Values)
            {
                Console.WriteLine(prop.GetValue(innerClass, null));
            }
        }   
    }

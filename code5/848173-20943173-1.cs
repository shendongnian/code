    public void MyFunction(object array)
    {
        dynamic dynArray = array;
        int length = dynArray.length;
        dynArray.push("d");
    
        SetAt(array, 1, "bb"); 
    
        Console.WriteLine("MyFunction called, array.length: " + length);
        Console.WriteLine("array[0]: " + GetAt(array, 0));
        Console.WriteLine("array[1]: " + GetAt(array, 1));
        Console.WriteLine("array[3]: " + GetAt(array, 3));
    }
    
    static object GetAt(object array, int index)
    {
        return array.GetType().InvokeMember(index.ToString(),
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty,
            null, array, new object[] { });
    }
    
    static object SetAt(object array, int index, object value)
    {
        return array.GetType().InvokeMember(index.ToString(),
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
            null, array, new object[] { value });
    }

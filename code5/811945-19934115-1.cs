    var prop = c.GetType().GetProperty(userInput,BindingFlags.Public | BindingFlags.Instance)
    if(prop != null && prop.CanWrite)
    {
        prop.SetValue(c,newValue,null);
    }

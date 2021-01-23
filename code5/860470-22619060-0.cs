    foreach (PropertyInfo prop in obj.GetType().GetProperties(
        BindingFlags.Public | BindingFlags.Instance))
    {
        if (prop.PropertyType != typeof(int)) continue;
        int val = (int)prop.GetValue(obj);
        if(val != 0) Console.WriteLine("{0}={1}", prop.Name, val);
    }

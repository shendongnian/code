    Type type = typeof(Sale);
    PropertyInfo[] info = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
    foreach (var i in info)
    {
        Debug.WriteLine(i.Name + " = " + i.GetValue(this, null));
    }

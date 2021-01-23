    var properties =
        from p1 in obj.GetType().GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public)
        from p2 in p1.PropertyType.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public).DefaultIfEmpty()
        select new { OuterProperty = p1, InnerProperty = p2 };
    
    foreach(var prop in properties)
    {
        Console.WriteLine(prop.OuterProperty.Name + (prop.InnerProperty != null ? "." + prop.InnerProperty.Name : ""));
    }

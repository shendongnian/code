    var properties =
        from p1 in obj.GetType().GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public)
        from p2 in p1.PropertyType.Namespace == "MyNamespace" 
            ? p1.PropertyType.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public).DefaultIfEmpty()
            : new PropertyInfo[] { null }
        select new { OuterProperty = p1, InnerProperty = p2 };

    var otherAssembly = typeof(/* Some type from the other assembly */).Assembly;
    // We look all the classes in an assembly for a static Main() that has
    // the "right" signature
    var main = (from x in otherAssembly.GetTypes()
                from y in x.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                where y.Name == "Main" && (y.ReturnType == typeof(int) || y.ReturnType == typeof(void)) && y.GetGenericArguments().Length == 0
                let parameters = y.GetParameters()
                where parameters.Length == 0 || (parameters.Length == 1 && parameters[0].ParameterType == typeof(string[]))
                select y).Single();
    if (main.GetParameters().Length == 0)
    {
        main.Invoke(null, null);
    }
    else
    {
        main.Invoke(null, new object[] { new string[0] });
    }

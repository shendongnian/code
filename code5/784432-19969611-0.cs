    foreach (var v in AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a=>a.GetTypes())
        .Where(a=>a.IsClass)
        .SelectMany(a=>a.GetProperties())
        .Where(a=>a.PropertyType == typeof(DateTime)))
              Console.WriteLine("{0}.{1}", v.DeclaringType, v.Name);

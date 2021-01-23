    var props = typeof( DateTime ).GetProperties().Where( i => names.Contains( i.Name ) );
    foreach (var prop in props)
    {
    	Console.WriteLine("{0}, Type {1}", prop.Name, prop.PropertyType);
    }

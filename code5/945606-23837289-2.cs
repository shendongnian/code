    List<string> names = GetDesiredListOfNamesSomehow();
    var props = typeof( DateTime ).GetProperties()
           .Where( i => names.Contains( i.Name ) ).Select( i => i.Name );
    foreach (var prop in props)
    {
    	Console.WriteLine("Prop Name: " + prop);
    }

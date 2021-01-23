    var names = new string[] {"Date", "Day", "DayOfWeek"};
    var props = typeof( DateTime ).GetProperties()
           .Where( i => names.Contains( i.Name ) ).Select( i => i.Name );
    foreach (var prop in props)
    {
    	Console.WriteLine("Prop Name: " + prop);
    }

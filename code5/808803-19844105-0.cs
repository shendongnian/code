    foreach (var ColorProperty in typeof(System.Drawing.SystemColors).GetProperties())
    {
        var Color = (System.Drawing.Color) ColorProperty.GetValue(null, null);
        Console.WriteLine("{0}, R={1}, G={2}, B={3}", ColorProperty.Name, Color.R, Color.G, Color.B);
    }

    var colorList = new List<System.Drawing.Pen>();
    foreach (var prop in typeof(System.Drawing.Color).GetProperties(BindingFlags.Public | BindingFlags.Static))
    {
        if (prop.PropertyType == typeof(System.Drawing.Color))
        {
            colorList.Add(new System.Drawing.Pen((System.Drawing.Color)prop.GetValue(null), 1f));
        }
    }

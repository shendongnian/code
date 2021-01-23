    var points = new List<Point>();
    var pointStrings = someString.Split(',');
    foreach (var p in pointStrings)
    {
        var pointString = p.Split(' ');
        if (pointString.Count() == 2)
        {
            var x = 0D;
            var y = 0D;
            if (!double.TryParse(pointString[0], out x))
                // handle error
            if (!double.TryParse(pointString[1], out y))
                // handle error
            points.Add(new Point { X = x, Y = y });
        }
        else
            // handle error
    }

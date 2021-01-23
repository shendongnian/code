    string str = @"(11,22)(2,3)(4,-10)(5,0)";
	Regex r = new Regex(@"(-?[0-9]+),(-?[0-9]+)");
	Match m = r.Match(str);
	var points = new List<System.Drawing.Point>();
	while (m.Success)
	{
		int x, y;
		if (Int32.TryParse(m.Groups[1].Value, out x) && Int32.TryParse(m.Groups[2].Value, out y))
		{
        	points.Add(new System.Drawing.Point(x, y));
		}
		m = m.NextMatch();
	}

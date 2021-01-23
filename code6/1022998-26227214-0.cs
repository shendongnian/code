	var colours =
		typeof(System.Drawing.Color)
			.GetProperties()
			.Where(x => x.PropertyType == typeof(System.Drawing.Color))
			.Select(x => x.Name)
			.ToArray();
	
	colorTextLabel.ForeColor =
		System.Drawing.Color.FromName(colours[rColour.Next(0, colours.Length)]);	

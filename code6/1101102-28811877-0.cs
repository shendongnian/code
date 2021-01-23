		CultureInfo culture = new CultureInfo("de-DE");
		string[] inputs = new string[]{"0,123456",
										"0,01",
										"1,123456",
										"0,0"};
		foreach(var input in inputs)
		{
		double val;
		if(Double.TryParse(input, NumberStyles.Number, culture, out val) 
			&& Math.Round(val, 6) == val
			&& val != 0.0
			&& (int)val == 0)
			Console.WriteLine("{0} is valid", input);
		else
			Console.WriteLine("{0} is invalid", input);
		}

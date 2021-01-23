		string input = "123ABC79";
		string pattern = @"\d+$";
		string replacement = "";
		Regex rgx = new Regex(pattern);
		var iterations = 1000000;
		var sw = Stopwatch.StartNew();
		for (int i = 0; i < iterations; i++)
		{
			rgx.Replace(input, replacement);
		}
		
		sw.Stop();
		Console.WriteLine("regex:\t{0}", sw.ElapsedTicks);
		var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		sw.Restart();
		for (int i = 0; i < iterations; i++)
		{
			input.TrimEnd(digits);
		}
		sw.Stop();
		Console.WriteLine("trim:\t{0}", sw.ElapsedTicks);

	    try
		{
			throw new FileNotFoundException{ Data ={ { "TEST", "Hello World" } } };
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Data["TEST"]);
			...
			e.Data.Add("Whatever", DateTime.Now);
		}

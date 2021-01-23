	DateTime dt = new DateTime();
	DateTime dt2 = new DateTime();
	
	dt = DateTime.Now;
	dt2 = dt.AddDays(20);
	
	TimeSpan ts = dt2.Subtract(dt);
	
	Console.WriteLine(ts.Days);

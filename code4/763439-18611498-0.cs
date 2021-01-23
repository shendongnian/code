    if (DateTime.Now.Hour > 16)
    {
    	MethodtoRunAt1600();
    }
    else
    {
    	var next16 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0);
    	var timer = new Timer(MethodtoRunAt1600, null, next16 - DateTime.Now, TimeSpan.FromHours(24));
    	timer.Start()
    }

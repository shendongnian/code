    void Main()
    {
    	DateTime startDate = DateTime.Today;
    	DateTime endDate = DateTime.Today.AddYears(1);
    	string selectedMode = "Monthly";
    	
    	var scheduleDateProv = new ScheduleDateProvider();
    	var dates = scheduleDateProv.GetDatesInRange(startDate, endDate, selectedMode);
    	
    	foreach(var dt in dates)
    		Console.WriteLine(dt.ToShortDateString());
    }

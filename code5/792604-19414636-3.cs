	var shifts = new List<Shift>
	{
		new Shift { Name = "C", BeginTime = new TimeSpan(22, 00, 00), LengthHours = 8 },
		new Shift { Name = "A", BeginTime = new TimeSpan(06, 00, 00), LengthHours = 8 },
		new Shift { Name = "B", BeginTime = new TimeSpan(14, 00, 00), LengthHours = 6 },
		new Shift { Name = "D", BeginTime = new TimeSpan(11, 00, 00), LengthHours = 8 }
	};
	var shiftRunning = findShift(shifts);

	var input = "/Date(1427565325073+0100)/";
	
	var dateVal = input.Substring(6, input.Length - 8);
	Console.WriteLine(dateVal);
	
	var parts = dateVal.Split('+');
	var milliseconds = long.Parse(parts[0]);
	var utcTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds);
	Console.WriteLine(utcTime);
	
	var localTime = utcTime;
	if (parts.Length > 1)
	{
		var hoursMinutes = int.Parse(parts[1]);
		localTime = localTime.AddHours(hoursMinutes / 100).AddMinutes(hoursMinutes % 100);
	}
	Console.WriteLine(localTime);

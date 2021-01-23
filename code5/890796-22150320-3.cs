	var inputList = new List<double>() {3.2, 4.5, 5.0};
	double total = inputList.Sum();
	int baseHours = (int)Math.Floor(total);
	int realBaseHours = (int)inputList.Sum(d => Math.Floor(d));
	if (baseHours > realBaseHours)
		throw new Exception("All hell breaks loose!");
	int baseMinutes = (int)(total * 100.0 - baseHours * 100.0);
	int finalHours = baseHours + baseMinutes / 60;
	int finalMinutes = baseMinutes % 60;
	double result = finalHours + finalMinutes / 100.0;

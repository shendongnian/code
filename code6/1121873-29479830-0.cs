	var dic = new ConcurrentDictionary<DateTime, int>();
	dic[new DateTime(2015, 4, 5, 7, 0, 1)] = 1;
	dic[new DateTime(2015, 4, 5, 7, 0, 2)] = 2;
	dic[new DateTime(2015, 4, 5, 7, 0, 3)] = 3;
	dic[new DateTime(2015, 4, 6, 7, 0, 1)] = 5;
	dic[new DateTime(2015, 4, 6, 7, 0, 2)] = 6;
	dic[new DateTime(2015, 4, 6, 7, 0, 3)] = 7;
	var searchDay = new DateTime(2015, 4, 5);
    // Find the values corresponding to the specified day
	var dates = dic.GroupBy(item => item.Key.Date).FirstOrDefault(x => x.Key == searchDay.Date);
	if (dates != null)
	{
		int max = dates.Max(x => x.Value);
        // That's the maximum value for the specified day
	}

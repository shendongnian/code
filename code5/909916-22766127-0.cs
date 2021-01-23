	var days = new List<int> { 1, 4, 5, 6, 7, 8, 20, 24, 25, 26, 30 };
	var groupNumber = 0;
	var longestGroup = days
		.Select((x, i) => new
				            {
					            Item = x,
					            Index = i
				            })
		.GroupBy(x => x.Index == 0 || x.Item - days[x.Index - 1] == 1
			? groupNumber :
			++groupNumber)
		.OrderByDescending(x => x.Count())
		.First()
		.Select(x => x.Item)
		.ToArray();
	Console.WriteLine(longestGroup.First()+", "+longestGroup.Last());

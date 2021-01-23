		var dict = new SortedDictionary<DateTime, RosterLine>();
		dict.Add(DateTime.Today, new RosterLine());
		// Does not work as RosterLine is a value type
		dict[DateTime.Today].ActCd = "SO";
		// Works, but means a lot of copying
		var temp = dict[DateTime.Today];
		temp.ActCd = "SO";
		dict[DateTime.Today] = temp;

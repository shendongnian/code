    var set1 = new Dictionary<int, string>();
	var set2 = new Dictionary<int, string>();
	var set3 = new Dictionary<int, string>();
	set1.Add(1, "Value01");
	set1.Add(2, "Value02");
	set1.Add(3, "Value03");
	set1.Add(4, "Value04");
	set1.Add(5, "Value05");
	set1.Add(6, "Value06");
	set1.Add(7, "Value07");
	set1.Add(8, "Value08");
	set1.Add(9, "Value09");
	set1.Add(10, "Value10");
	set2.Add(1, "ValueA");
	set2.Add(2, "ValueB");
	set2.Add(3, "Value01");
	set2.Add(4, "ValueD");
	set2.Add(5, "Value17");
	set2.Add(6, "ValueX");
	set2.Add(7, "ValueY");
	set2.Add(8, "ValueZ");
	set2.Add(9, "Value16");
	set3.Add(1, "ValueT");
	set3.Add(2, "Random");
	set3.Add(3, "Duck");
	set3.Add(4, "Arg");
	set3.Add(5, "Value03");
	set3.Add(6, "Value01");
	set3.Add(7, "ValueD");
	set3.Add(8, "ValueB");
	set3.Add(9, "Whatever");
	var search = set1.Select(kvp => new MyData { SetID = 1, ID = kvp.Key, Value = kvp.Value })
		.Concat(set2.Select(kvp => new MyData { SetID = 2, ID = kvp.Key, Value = kvp.Value })
	).Concat(set3.Select(kvp => new MyData { SetID = 3, ID = kvp.Key, Value = kvp.Value })
	).GroupBy(md => md.Value);
	var unique = new HashSet<MyData>();
    var dupes = new HashSet<MyData>();
	foreach (var grp in search) {
		if (grp.Take(2).Count() > 1) {
			foreach (var data in grp) dupes.Add(data);
		} else {
			unique.Add(grp.Single());
		}
	}
	foreach (var data in unique) Console.WriteLine(data);
	Console.WriteLine();
	foreach (var data in dupes) Console.WriteLine(data);

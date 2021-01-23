	var l = new List<Tuple<int, int>>();
	l.Add(new Tuple<int, int>(1, 1));
	l.Add(new Tuple<int, int>(1, 2));
	var s = l.Select(k => k.Item1.ToString() + "," + k.Item2.ToString());
	var q = Tests.Where(t => s.Contains(t.K1.ToString() + "," + t.K2.ToString()));
	foreach (var y in q) {
		Console.WriteLine(y.Name);
	}

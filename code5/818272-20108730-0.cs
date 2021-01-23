	var a = new List<int>() { 1, 2, 3, };
	var b = new List<int>() { 1, 3, 4, 5, };
	
	foreach (var x in a.Except(b).ToArray())
	{
		a.Remove(x);
	}
	
	foreach (var x in b.Except(a).ToArray())
	{
		a.Add(x);
	}

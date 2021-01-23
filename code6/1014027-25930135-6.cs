	var a = new List<string> { "a", "b", "c" };
	var b = new List<string> { "c", "d", "e" };
	for(int i = 0; i < a.Count; i++)
		if(b.Contains(a[i]))
			b.Remove(a[i]);
		else
			a.Remove(a[i--]);

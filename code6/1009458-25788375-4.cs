    List<Group> _groups = new List<Group>();
	
	for (int i = 0; i < 10000; i++)
	{
	    var group = new Group();
	
	    group.Name = i + "asdasdasd";
	    _groups.Add(group);
	}
			
	IEnumerable<Group> _groupsEnumerable = from g in _groups select g;
	
	Stopwatch _stopwatch2 = new Stopwatch();
	
	_stopwatch2.Start();
	foreach (var group in _groups)
	{
	    var count = _groupsEnumerable.Count(x => x.Name == group.Name);
	}
	_stopwatch2.Stop();
	
	Console.WriteLine(_stopwatch2.ElapsedMilliseconds);
	Stopwatch _stopwatch = new Stopwatch();
	
	_stopwatch.Start();
	foreach (var group in _groups)
	{
	    var count = _groupsEnumerable.Where(x => x.Name == group.Name).Count();
	}
	_stopwatch.Stop();
	
	Console.WriteLine(_stopwatch.ElapsedMilliseconds);

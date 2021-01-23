    List<Process> processList = new List<Process>() 
	{
		new Process() { Id = "1", name = "1", Type = 7},
		new Process() { Id = "2", name = "2", Type = 1},
		new Process() { Id = "3", name = "3", Type = 4},
		new Process() { Id = "4", name = "4", Type = 3},
		new Process() { Id = "5", name = "5", Type = 9},
		new Process() { Id = "6", name = "6", Type = 8},
	};
	List<int> sequence = new List<int>() { 7, 3, 4, 1 };
	var pl = processList.Where(p => sequence.Contains(p.Type)).OrderBy(p => sequence.IndexOf(p.Type)).Union(processList.Where(p => !sequence.Contains(p.Type)).OrderBy(p => p.Type));

    public bool MatchesMyCondition(string line) {...}
    public void DoSomething(List<string> lines) {...}
	List<string> lines = new List<string>();
	string line;
    System.IO.StreamReader file = new System.IO.StreamReader("myFile.txt");
	while((line = file.ReadLine()) != null)
	{
		if (MatchesMyCondition(line))
		{
		   DoSomething(lines);
		   lines.Clear();
		}
		else
		{
			lines.Add(line);
		}
	}
	//handle the last items
	DoSomething(lines);

	List<String> exampleList = new List<String>();
	exampleList.Add("This is a house.");
	exampleList.Add("I am writing with pen");
	int index = exampleList.FindIndex(x => x.Contains("house"));
	Console.WriteLine(index); //0
	index = exampleList.FindIndex(x => x.Contains("pen"));
	Console.WriteLine(index); //1

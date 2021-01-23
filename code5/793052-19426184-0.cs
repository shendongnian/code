    List<List<string>> ListA = new List<List<string>>();
    List<List<string>> ListsToAdd = new List<List<string>>();
    foreach (List<string> subList in ListA)
	{
		foreach (var value in subList)
		{
			   if(value != INPUT)
			   (
				  List<string> list = new List<string>();
				  list.Add(INPUT);
				  ListsToAdd.Add(list);
			   }
		}
	}
    ListA.AddRange(ListsToAdd);

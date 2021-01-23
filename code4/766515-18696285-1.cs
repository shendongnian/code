    List<string> checkForNull = new List<string>();
    List<string> newList = new List<string>();
    for (int i = 0; i < 10; i++)
    {
    	checkForNull.Add(Convert.ToString(i));
    }
    for (int i = 10; i < 20; i++)
    {
    	newList.Add(Convert.ToString(i));
    }
    checkForNull.AddRange(newList.Take(5));
    newList.RemoveRange(0, 5);

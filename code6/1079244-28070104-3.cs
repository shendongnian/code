    List<List<int>> listOfLists = new List<List<int>> { 
                            new List<int> { 1, 2, 5 }, 
                            new List<int> { 2, 1, 7 }, 
                            new List<int> { 0, 5, 3 } };
                
    foreach (var list in listOfLists)
    {
        list.Sort();
    }
    var sorted = listOfLists.OrderBy(l => l.First());
                
    foreach (var list in sorted)
    {
        Console.WriteLine(string.Join(" ", list));
    }

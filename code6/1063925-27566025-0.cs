    var copies = 2; // Or whatever
    var newList = new List<string>(oldList.Count * copies);
    foreach (var item in oldList)
    {
        for (int i = 0; i < copies; i++)
        {
            newList.Add(item);
        }
    }

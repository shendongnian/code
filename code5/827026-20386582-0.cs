    List<Test> testList = new List<Test>();
    // list is somehow populated with items
    var pct = (double)(100 / testList.Count);
    var range = (int)(1.0/pct);
    var rnd = new Random();
    var selectedItems = new List<Test>();
    for (var i = 0; i < testList.Count; ++i)
    {
        if (rnd.Next(range) == 0)
        {
            selectedItems.Add(testList[i]);
        }
    }

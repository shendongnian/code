    List<Test> testList = new List<Test>();
    // list is somehow populated with items
    var range = (int)((double)testList.Count/100);
    var rnd = new Random();
    var selectedItems = new List<Test>();
    for (var i = 0; i < testList.Count; ++i)
    {
        if (rnd.Next(range) == 0)
        {
            selectedItems.Add(testList[i]);
        }
    }

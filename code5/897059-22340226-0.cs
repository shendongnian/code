    var existsItems = ComputerDataGridListTest.Where(x => x.ComputerId == test2);
    if(existsItems.Any())
        foreach(var item in existsItems)
            item.Term = test2;
    else
        ComputerDataGridListTest.Add(new ComputerDataGridBO()
        {
            Term = test1,
            ComputerId = test2
        });

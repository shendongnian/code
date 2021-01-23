    //make a linked list and fill it...
    LinkedList<int> list = new LinkedList<int>(Enumerable.Repeat(0,10));
    
    list.AddLast(0);
    while(list.Count > 10)
    {
    	list.RemoveFirst();
    }
    var avg = list.Average();

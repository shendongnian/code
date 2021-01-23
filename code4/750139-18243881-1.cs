    void Main()
    {
        // Assume below list is your dataset 
        var myList =new List<dynamic>(new []{
	    new {ColumnKey=1, ColumnValue  ="Two"},
	    new {ColumnKey=2, ColumnValue  ="Nine"},
	    new {ColumnKey=3, ColumnValue  ="One"},
	    new {ColumnKey=4, ColumnValue  ="Eight"}});
	
        var result = myList.Select(p => new 
                                {
                                    ColVal = 	p.ColumnValue,
                                    OrderKey = 	p.ColumnValue == "Three" ? 1 : 
                                                p.ColumnValue == "One"   ? 2 : 
                                                p.ColumnValue == "Two"   ? 3 : 4
                                 }).Where(i=> i.OrderKey != 4)
                                 .OrderBy(i=>i.OrderKey)
                                 .Select(i=> i.ColVal)
                                 .FirstOrDefault();
        Console.WriteLine(result ?? "Four");
    }

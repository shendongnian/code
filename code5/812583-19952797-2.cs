    List<Table> table = new List<Table>() { 
    	new Table(1, 1, 1, "A"),
    	new Table(2, 1, 2, "B"),
    	new Table(3, 2, 1, "C"),
    	new Table(4, 2, 2, "D")
    };
    
    List<string> rowsTable1 = table.GroupBy(x => x.RowID)
    							   .Select(x => string.Join(",", x.Select(y => y.Cellvalue).ToArray()))
    							   .ToList();
    
    
    List<Table> table2 = new List<Table>() { 
    	new Table(1, 1, 1, "X"),
    	new Table(2, 1, 2, "Y"),
    	new Table(3, 6, 1, "A"),
    	new Table(4, 6, 2, "C"),
    	new Table(5, 8, 1, "A"),
    	new Table(6, 8, 2, "B"),
    	new Table(7, 9, 1, "A"),
    	new Table(8, 9, 2, "B")
    };
    
    List<Table> table3 = table2.GroupBy(x => x.RowID)
    						   .Where(x => rowsTable1.Contains(string.Join(",", x.Select(y => y.Cellvalue).ToArray())))
    						   .SelectMany(x => x.Select(y => y))
    						   .ToList();

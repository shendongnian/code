    List<table> table = new List<table>() { 
    	new table(1, 1, 1, "A"),
    	new table(2, 1, 2, "B"),
    	new table(3, 2, 1, "C"),
    	new table(4, 2, 2, "D")
    };
    
    List<string> rowsTable1 = table.GroupBy(x => x.RowID)
    						       .Select(x => string.Join(",", x.Select(y => y.Cellvalue).ToArray()))
    						       .ToList();
    
    
    List<table> table2 = new List<table>() { 
    	new table(1, 1, 1, "X"),
    	new table(2, 1, 2, "Y"),
    	new table(3, 6, 1, "A"),
    	new table(4, 6, 2, "C"),
    	new table(5, 8, 1, "A"),
    	new table(6, 8, 2, "B"),
    	new table(7, 9, 1, "A"),
    	new table(8, 9, 2, "B")
    };
    
    List<table> table3 = table2.GroupBy(x => x.RowID)
    						   .Where(x => rowsTable1.Contains(string.Join(",", x.Select(y => y.Cellvalue).ToArray())))
    						   .SelectMany(x => x.Select(y => y))
    						   .ToList();

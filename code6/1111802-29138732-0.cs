    // Get matching rows from the two tables
    IEnumerable<DataRow> matchingRows = table1.AsEnumerable().Intersect(table2.AsEnumerable());
   
    // Get rows those are present in table2 but not in table1
    IEnumerable<DataRow> rowsNotInTableA = table2.AsEnumerable().Except(table1.AsEnumerable()); 

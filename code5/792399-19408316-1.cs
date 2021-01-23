    string newcolExpression = @"' ' + " + string.Join(" + ",GroupByColumns) ; // prepend a space to ensure string concatenation
    // e.g. "' ' + ID1 + ID2"
    
    dt.Columns.Add("GroupBy",typeof(string),newcolExpression);
    
    dt = dt.AsEnumerable()
           .GroupBy(r => r["GroupBy"])
           .Select(g => g.OrderBy(r => r["PK"]).First())
           .CopyToDataTable();
    		 
    dt.Columns.Remove("GroupBy");

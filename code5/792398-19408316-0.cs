    string newcol = @"' ' + " + string.Join(" + ",GroupByColumns) ; // prepend a space to ensure string concatenation
    
    dt.Columns.Add("GroupBy",typeof(string),newcol);
    
    dt = dt.AsEnumerable()
           .GroupBy(r => r["GroupBy"])
           .Select(g => g.OrderBy(r => r["GroupBy"]).First())
           .CopyToDataTable();
    		 
    dt.Columns.Remove("GroupBy");

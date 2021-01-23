    string[][] mergeBlockData = 
         new List<string[]>{ dt.Columns.OfType<DataColumn>().Select(dc => dc.ColumnName).ToArray() }.Concat(
         dt.Rows.OfType<DataRow>()
    	     .Select(
    		r => dt.Columns.OfType<DataColumn>()
    			.Select(c => r[c.ColumnName].ToString()).ToArray()
    	     )
         )
        .ToArray();

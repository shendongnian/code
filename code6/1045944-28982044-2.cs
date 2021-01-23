    sourceTable.ColumnChanged += (s, e) =>
    {
    	// check if the updated column is one of the columns that were reflected
    	if (reflectedColumnsMap.ContainsKey(e.Column.ColumnName))
    	{
    		// get the target row corresponding to the updated row in the source table
    		DataRow reflectedRow = sourceToTargetRowMap[e.Row];
    		// update the corresponding columns in the target table
    		foreach (string targetColumn in reflectedColumnsMap[e.Column.ColumnName])
    		{
    			// update the value
    			reflectedRow[targetColumn] = e.Row[e.Column.ColumnName];
    		}
    	}
    };

    DataRow rRow = default(DataRow);
    for (intI = 0; intI <= lstColumns.Count - 1; intI++)
    {
    	if (lstColumns.Item(intI).tablename == strCurrentTable) 
            {
    		rRow(lstColumns.Item(intI).ColumnName) = lstColumns.Item(intI).ColumnData;
    	}
    }

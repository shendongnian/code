    for (intI = 0; intI <= lstColumns.Count - 1; intI++)
    {
    	if (lstColumns(intI).ToString() == strCurrentTable)
        {
    		rRow(lstColumns(intI)) = lstColumns(intI).ToString();
    	}
    }

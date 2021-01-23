	var primaryKeys = new string[dataTableOne.Rows.Count];
	var dataTables = new DataTable[dataTableOne.Rows.Count] ;
	
	for (int i= 0 ; i < dataTableOne.Rows.Count ; i++)
	{
		dataTables[i] = new DataTable();
		primaryKeys[i] = (string) dataTableOne.Rows[i]["PrimaryColumn"];
	}

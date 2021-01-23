	List<SqlMetaData> columnsInfo = new List<SqlMetaData>(); 
	
	foreach (string entry in poodle.getKs())
	{
		columnsInfo.Add( new SqlMetaData(entry, SqlDbType.Text));
	}
	
	SqlDataRecord record = new SqlDataRecord(columnsInfo.ToArray<SqlMetaData>()); 

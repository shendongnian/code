	List<DynamicDataRecord> records = new List<DynamicDataRecord>();
	using (SqlDataReader reader1 = cmd1.ExecuteReader()) 
	{
		while(reader1.Read())
		{
			records.Add( new DynamicDataRecord(record));
		}
	}

	private void Load_data(AseDataReader reader, List<myclass1> table)
    {
        while (reader.Read())
        {
            table.Add(new myclass1
            {
                id_number= SafeGetInt(reader, 0),
                state = SafeGetString(reader, 1)
            });
        }
    }
	

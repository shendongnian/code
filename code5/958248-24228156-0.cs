    datagridtampil.Rows.Clear();
    if (reader.HasRows)
    {
    	int j = 0;
    	while (reader.Read())
    	{
    		j = datagridtampil.Rows.Add()
    		for (int i = 1; i < datagridtampil.Columns.Count; i++)
    		{
    			datagridtampil.Rows[j].Cells[i].Value = reader.GetValue(i-1).ToString();
    		}
    	}
    }

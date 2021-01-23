    string ConvertDatasetToString(DataSet Ds)
    {
    	string OUT = "";
    	for (int t = 0; t < Ds.Tables.Count; t++)
    	{
    		for (int r = 0; r < Ds.Tables[t].Rows.Count; r++)
    		{
    			for (int c = 0; c < Ds.Tables[t].Columns.Count; c++)
    			{
    				string s = Ds.Tables[t].Rows[r][c].ToString();
    				OUT += s;
    			}
    		}
    	}
    	return OUT;
    }

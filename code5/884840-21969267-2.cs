    string RowFind()
    {
    	using (var Connection = new SqlConnection(DatabaseConnection))
    	{  
    		Connection.Open();
    		string queryString = string.Format("SELECT * FROM ShopSentences");
    		SqlDataAdapter sda = new SqlDataAdapter(queryString, Connection);
    		DataTable dt = new DataTable("ShopSentences");
    		sda.Fill(dt);
    		//Connection.Close();
    		return dt.Rows[dt.Rows.Count - 1]["RowNumber"].ToString();
    	}
    }

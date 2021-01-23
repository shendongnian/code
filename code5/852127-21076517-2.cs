    public DataSet SelectQuery(string[] coloumns,string[] tables,string cond)
    {
        using (SqlConnection DBcon= new SqlConnection(this.ConStr))
        {
			string col = string.Join(",", coloumns);
			string tbl = string.Join(",", tables);
			string selectSQL = "SELECT " + col + " FROM " + tbl + cond;
			SqlCommand cmd = new SqlCommand(selectSQL, this.DBcon);
			SqlDataAdapter ada = new SqlDataAdapter();
			DataSet retrnds = new DataSet();
			try
			{
				 this.DBcon.Open();
				 ada.SelectCommand = cmd;
				 ada.Fill(retrnds);
			}
			catch (Exception err)
			{
				 string error = err.ToString();
			}
			//no need for this.DBcon.Close();
			
			return retrnds;
        }
    }		

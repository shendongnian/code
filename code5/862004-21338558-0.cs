    class Data {
    	public int StudentId {get;set;}
    	public string Name {get;set;}
    	public string Address {get;set;}
    }
    
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
    	var datas = new List<Data>();
        try
        {
    		StringBuilder sql = new StringBuilder();
    		foreach(data in datas)
    		{
    			sql.Append(String.Format("INSERT into Student VALUES({0},'{1}','{2}') ",data.UserId,data.Name,data.Address));
    		}
    		
    		var sqlConnection = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=Lab1;Trusted_Connection=True;");
    		sqlConnection.Open();
    		var command = new SqlCommand(sql.ToString(),sqlConnection);
    		command..ExecuteNonQuery();
    		sqlConnection.Close();
    		
    	}
    	catch(SqlException ex){
    		MessageBox.Show("Database failed" + ex.Message);
    	}
    }

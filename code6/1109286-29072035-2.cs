    //defin sample array list or your data
    ArrayList array = new  ArrayList();
    
    //fill array with some data
    for (int i = 1000; i<1010;i++)
    	array.Add(i);
    
    //define connection and command
    using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
    {
    	connection.Open();
    	SqlCommand cmd = new SqlCommand("",connection);
    	cmd.Parameters.AddWithValue("@list_entry", SqlDbType.varchar,8000,Get_comma_delimited_string(array));
    	cmd.CommandType = CommandType.StoredProcedure;
    	cmd.CommandText = "yourSpName";
    	cmd.ExecuteNonQuery();
    }
    
    /// <summary>
    /// Resturns a comma delimited string (sepearte each item in list with ',' )
    /// </summary>            
    public string Get_comma_delimited_string(ArrayList arrayList)
    {
    	string result = string.Empty;
    	foreach (object item in arrayList)
    		result += item.ToString() + ",";
    
    	return result.Remove(result.Length - 1);
    }

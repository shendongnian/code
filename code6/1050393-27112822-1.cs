    public DataTable Select(string query, Dictionary<string, object> values = null)
    {
        using(SqlConnection myConnection = new SqlConnection(connectionString))
        {
            using(SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                myConnection.Open();
    
                if(values != null)
                {
                    foreach(var item in values)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                }
                
                cmd.CommandType = CommandType.Text;
    			sda = new SqlDataAdapter(cmd);
    			dt = new DataTable("YourDataTable");
    			new SqlDataAdapter(cmd).Fill(dt);            
            }
        }
        return dt
    }

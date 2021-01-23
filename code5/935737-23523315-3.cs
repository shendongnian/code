    public class MySqlConnector
    {
    	private MySqlCommand command;
    
    	public void CreateView()
    	{
    		if(command == null)
    		{
    			command = new MySqlCommand();
    		}
    		command.Parameters.AddWithValue("@ContactID", "10");
    		var sql = "Create View r2_Add_Edit_View as SELECT era.contact_id, era.n_family FROM era WHERE era.contact_id = @ContactID";
    		command.CommandText = sql;
    		command.Connection = con;
    		command.ExecuteNonQuery();
    		con.Close();
    	}
    }

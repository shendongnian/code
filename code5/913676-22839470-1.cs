    public class Whatever
    {
    	public List<Company> clientList()  // Select from customer table in MySQL db
    	{
    		string query = "SELECT " + thisItem + " FROM " + thisTable;
    		// Create list to store the results result
    		List<Company> list = new List<Company>();
    		if (this.OpenConnection() == true) // Open connection 
    		{
    			MySqlCommand cmd = new MySqlCommand(query, connection); // Create Command
    			MySqlDataReader dataReader = cmd.ExecuteReader(); // Create data reader and Execute command
    			
    			// Read data and store in list
    			// Request data from SQL db
    			Console.WriteLine("AQUIRRING DATA FROM SQL SERVER....");
    			while (dataReader.Read())
    			{
    				if (thisItem == "*" && (thisTable == "CUSTOMER") || (thisTable == "customer"))
    				{
    					Company newCompany = new Company();
    		
    					newCompany.ID = dataReader["ID"].ToString();
    					newCompany.Name = dataReader["NAME"].ToString();
    					...
    					...
    					... (You get the jist of it.)
    					
    					list.add(newCompany);
    				}
            		            
    			}    
    			
    			dataReader.Close();
    		
    			this.CloseConnection(); //Close Connection
    			return list;       // Return list to be used
    		}
    		return list;
    	}
    }
    
    public class Company
    {
    	ID {get;set;}
    	NAME {get;set;}
    	COMPANY {get;set;}	
    	PLANT {get;set;}
    	CITY {get;set;}
    	STATE {get;set;}
    	CREATED {get;set;}
    	VIEWED	{get;set;}
    	MODIFIED {get;set;}
    }

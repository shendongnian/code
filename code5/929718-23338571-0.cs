    public class CustomerDatabase : SQLiteConnection
    {
    	public CustomerDatabase(string filename) : base(filename, true)
    	{
    		//This will open the database file specified by filename
    	}	
    }

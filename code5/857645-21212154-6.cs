    public class Database
    {
    	....
    	public Form FormInstance;
    	
    	public Database(Form formInstance)
    	{
    		....
    		FormInstance = formInstance;
    		....
    	}
    	....
    	internal bool Logon(string username,string password)
    	{
    		// blah blah...
    		logon = DateTime.Now.ToString() + " - Username " + username + " just logged on";
    		FormInstance.listBox1.Items.Add(logon);
    	}
    	.....
    }
        
    //in Form, when creating Database instance pass current Form instance as parameter
    private Database _database;
    public Form()
    {
    	....
    	_database = new Database(this);
    	....
    }

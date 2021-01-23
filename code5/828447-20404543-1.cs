    public interface class IClient
    {
    	string ConnectionString {get;set;}
    }
    public class DataAccess
    {
    	private IClient _connectionString;
    	
    	public DataAccess(IClient client)
    	{
    		_connectionString = client.ConnectionString;
    	}
    }

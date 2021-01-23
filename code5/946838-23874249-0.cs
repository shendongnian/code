    // Domain object
    public class Person
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    }
    
    // Data Access Layer
    public class MongoAccessLayer : IDal
    {
    	public void SaveEntity<T>(T entity)
    	{
    		// Save logic here
    	}
    
        public void LoadEntity<T>(T entity)
        {
    	// Load logic here
        }
    }
    
    // Interface defining what the access layer should look like
    public interface IDal
    {
    	void SaveEntity<T>(T entity);
    	void LoadEntity<T>(T entity);
    }

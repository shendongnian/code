    public class UnitOfWork
    {
    	private object connectionInformation;
    	public UnitOfWork(object connectionInformation)
    	{
            // set up your connection information
    		this.connectionInformation = connectionInformation;
            
            this.CustomerRepository = new GenericRepository<Customer>(connectionInformation);
 		    this.BookRepository = new GenericRepository<Book>(connectionInformation);
    	}
    	public GenericRepository<Book> BookRepository { get; private set; }
 		public GenericRepository<Customer> CustomerRepository { get; private set; }
    }

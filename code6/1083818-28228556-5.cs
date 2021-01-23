    public class UnitOfWork
    {
    	private object connectionInformation;
    	public UnitOfWork(object connectionInformation)
    	{
            // set up your connection information
    		this.connectionInformation = connectionInformation;
            
            this.CustomerRepository = new CustomerRepository(connectionInformation);
 		    this.BookRepository = new BookRepository(connectionInformation);
    	}
    	public CustomerRepository { get; private set; }
 		public BookRepository { get; private set; }
    }

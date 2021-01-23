    public class HandleUserStats : ICommandHandler<UserStats>
    {
	    protected IRepository repository;
	
        public HandleUserStats(IRepository repository)
    	{
    		this.repository = repository;
    	}
	
    	public void Handle(UserStats stats)
    	{
    		// do something
    	}
    }

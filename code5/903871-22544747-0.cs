    public sealed class CurrentMoment
    {
    	private static CurrentMoment s_instance;
    	//private Moment m_moment;
    	private CurrentMoment()
    	{
    	}
    
    	public static CurrentMoment Instance
    	{
    		get
    		{
    			if (s_instance == null)
    				s_instance = new CurrentMoment();
    
    			return s_instance; 
    		}
    	}
    
    	/// <summary>
    	/// Gets or sets the moment.
    	/// </summary>
    	/// <value>The moment.</value>
    	public Moment Moment
    	{
    		get;
    		set;
    	}
    }

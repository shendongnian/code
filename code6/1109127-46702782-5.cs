    public class Entity1 : BaseModel
    	{
    		public int ItemName
    		{
    			get;
    			set;
    		}
    	}
	public class Entity2 : BaseModel
	{
		public int Description
		{
			get;
			set;
		}
	}
    public static UnityContainer Container { get; private set; }
    
    	public static void InitializeUnityContainer()
    	{
    		if (Container == null)
    			Container = new UnityContainer();
    	}

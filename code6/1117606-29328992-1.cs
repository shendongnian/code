    public class BaseClass
    {
        private string gameObject;
    	private bool isAlive;
    	private int level;
    
    	public BaseClass(string gameObjectStructure)
    	{
    		this.gameObject = gameObjectStructure;
    		level = 1;
    	}
    	//don't include a set property to prevent anyone from changing the value
    	public string GameObject { get { return gameObject; } }
    	//"normal" property which includes a way to set and get the value
    	public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
    	//Include virtual which allows the child classes to override the behavior
    	public virtual Level { get { return level; } set { level = value; } }
    }
    public SpecificObject : BaseClass
    {
    	private string levelMessage;
    	public SpecificObject(string objectname) : base(objectname)
    	{
    		//No need to call base.gameObject = objectName; because that is what
    		//base(objectname) is doing for you.
    		levelMessage = String.Empty;
    	}
    	//Contrived example showing overrides on a virtual method.
    	public override Level 
    	{
    		get { return base.Level } 
    		set { 
    				base.Level = value;
    				levelMessage = value.ToString();
    			} 
    	}
    }

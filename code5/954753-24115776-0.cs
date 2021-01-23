    abstract class C : I, UserControl
    {
    	private string _str;
    	    public string str
    	{
    	    get { return _str; }
    	    set { _str = value; }
    	}  
    
    	public C(string someStr)
    	{
    		_str = someStr;
    	}
    }
    
    
    class A : C
    {
    	public A() : base("From a")
    	{
    
    	}
    }

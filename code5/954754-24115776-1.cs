    class A : C
    {
    	public A() : base("From a")
    	{
    
    	}
    }
    abstract class C : I, UserControl
    {
    	public string Str {get; set;}  
    
    	protected C(string someStr)
    	{
            Str = someStr;
    	}
    }
    
    

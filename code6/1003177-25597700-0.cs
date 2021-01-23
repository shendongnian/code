    public class Base
    {
    	private float a;
    	protected float b;
    	public float c;
    	
    }
    
    
    public class Sub : Base
    {
        public void DoSomething()
    	{
    	   float x = base.a; // Error cannot access private member a
           // Note that putting base before b and c here is optional
           // though it does help with naming conflicts 
           // if Sub would also have a member b you could differentiate the two
           // using this.b and base.b
    	   float y = base.b; // Works
    	   float z = base.c; // Works
    	}
    }

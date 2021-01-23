    public class X 
    {
        public virtual string A
    	{
    		get	{ return "Foo"; }
    	}
    	
        public virtual string X()
    	{
            return A;
        }
    }
    public class Y : X
    {
        public override string A
    	{
    		get { return "Bar"; }
    	}
    }

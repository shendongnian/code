    public class Class1
    {
    	public Class1()
    	{
    		var c = new Class2();
    		c.OnFinish += result => 
    		{
    			// My result handling here
    		};
    	}
    }
    
    public class Class2
    {
    	public event Action<string> OnFinish;
    
    	private void SomeMethod()
    	{
    		string result = "Result here";
    
    		var eventHandler = this.OnFinish;
    
    		if (eventHandler != null)
    		{
    			eventHandler(result);
    		}		
    	}
    }

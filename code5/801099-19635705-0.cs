    public abstract class BaseViewModel
    {
    	protected BaseViewModel()
    	{
    		foo = new Foo();
    	}
    	
    	public Foo foo { get; set; }
    }

    public class SomeClassFactory
    {
    	private readonly IKernel _kernel;
    	
    	public SomeClassFactory(IKernel kernel)
    	{
    		_kernel = kernel;
    	}
    	
    	public SomeClass Create(string name, bool isChild)
    	{
    		var childString = (isChild) ? "Child" : "Nope";
    		return _kernel.Get<SomeClass>(new ConstructorArgument("someName", childString));
    	}
    }

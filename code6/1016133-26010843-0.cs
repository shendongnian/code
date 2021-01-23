    public class MyClass
    {
    	public MyClass(MyDependency dependency)
    	{
    		if (dependency == null)
    		{
    			throw new ArgumentNullException("dependency");
    		}
    	}
    }
    
    [Test]
    public void ConstructorShouldThrowOnNullArgument()
    {
    	Assert.Catch<ArgumentNullException>(() => new MyClass(null));
    }

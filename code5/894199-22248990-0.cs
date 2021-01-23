    public class Base
    {
    	private bool Test { get { return true; } }
    	protected bool Test2 { get { return true; } }
    }
    public class A : Base { }
    public class B : Base { }
    
    [TestMethod]
    public void _Test()
    {
        object obj = new A(); // or new B()			
        			
        Assert.IsNotNull(typeof(Base).GetProperty("Test", BindingFlags.Instance | BindingFlags.NonPublic));
        Assert.IsNotNull(typeof(Base).GetProperty("Test2", BindingFlags.Instance | BindingFlags.NonPublic));
        
        Assert.IsNull(typeof(A).GetProperty("Test", BindingFlags.Instance | BindingFlags.NonPublic));
        Assert.IsNotNull(typeof(A).GetProperty("Test2", BindingFlags.Instance | BindingFlags.NonPublic));
        
        Assert.IsNull(typeof(A).GetProperty("Test", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
        Assert.IsNotNull(typeof(A).GetProperty("Test2", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
        
        Assert.IsNull(obj.GetType().GetProperty("Test", BindingFlags.Instance | BindingFlags.NonPublic));
        Assert.IsNotNull(obj.GetType().GetProperty("Test2", BindingFlags.Instance | BindingFlags.NonPublic));
        Assert.IsNotNull(obj.GetType().BaseType.GetProperty("Test", BindingFlags.Instance | BindingFlags.NonPublic));
        Assert.IsNotNull(obj.GetType().BaseType.GetProperty("Test2", BindingFlags.Instance | BindingFlags.NonPublic));
    }

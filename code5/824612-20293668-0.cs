    public class Base
    { }
    
    public class Derived : Base
    { }
    
    [TestMethod]
    public void BaseDerivedTest()
    {
        Base b = Activator.CreateInstance(typeof(Derived).BaseType);
        Assert.IsInstanceOfType(b, typeof(Base));
    }

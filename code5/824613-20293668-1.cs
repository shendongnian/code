    public class Base
    { }
    
    public class Derived : Base
    { }
    
    [TestMethod]
    public void BaseDerivedTest()
    {
        string type = "Derived"; // type is found somewhere upstream
        if (type == "Derived")
        {
            var b = Activator.CreateInstance(typeof(Derived).BaseType);
            Assert.IsInstanceOfType(b, typeof(Base));
        }
    }

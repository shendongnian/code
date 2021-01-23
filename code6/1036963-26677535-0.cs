    [TestClass]
    public abstract class TestBase
    {
         protected abstract IMyInterface GetObjectToTest();
    
         [Test]
         public void TestMethod()
         {
              IMyInterface objectToTest = GetObjectToTest();
              //Do your generic test of all implementations of IMyInterface
              objectToTest.Setup();
              //...
              Assert.Equal(objectToTest.Property,100);
              //etc
         }
    }
    
    [TestClass]
    public class ConcreteTestClass : TestBase
    {
        protected override GetObjectToTest()
        {
             return new ConcreteImplementationOfIMyObject();
        }
 
        [Test]
        public void TestConcreteImplementationOfIMyObjectSpecificMethod()
        {   
            //test method for stuff which only applies to ConcreteImplementationOfIMyObject types
        }
     }

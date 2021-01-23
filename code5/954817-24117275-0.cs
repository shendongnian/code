    [TestClass]
    public class MyTests
    {
       [ClassInitialize]
       public void ClassInitialize() { Debug.Print("Running ClassInitialize"); }
    
       [TestInitialize]
       public void TestInitialize() { Debug.Print("Running    TestInitialize"); }
     
       [TestMethod]
       public void TestMethod1() { Debug.Print("Running       TestMethod1....."); }
    
       [TestMethod]
       public void TestMethod2() { Debug.Print("Running       TestMethod2....."); }
       
       [TestCleanup]
       public void TestCleanup() { Debug.Print("Running    TestCleanup"); }
    
       [ClassCleanup]
       public void ClassCleanup() { Debug.Print("Running ClassCleanup"); }
    }

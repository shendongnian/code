    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    public class ScriptsBase
    {
        public static TestContext BingTestContext { get; set; }
    
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public virtual void MyTestInitialize()
        {
            BingTestContext = this.TestContext;
        }
    
        [TestCleanup]
        public virtual void MyTestCleanup()
        {
        }
    }
    
    [TestClass]
    public class DestinationMasterTestScripts : ScriptsBase
    {
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
        }
    
        [TestMethod]
        public void Foo()
        {
            Console.WriteLine(this.TestContext);
        }
    }

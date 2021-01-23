        [TestClass]
        public class MyTestClass
        {
    
            public TestContext TestContext { get; set; }
    
            /// <summary>
            /// Run before each UnitTest to provide additional contextual information.
            /// TestContext reinitialized before each test, no need to clean up after each test.
            /// </summary>
            [TestInitialize]
            public void SetupTest()
            {
                TestContext.Properties.Add("MyKey", "My value ...");
    
                switch (TestContext.TestName)
                {
                    case "MyTestMethod2":
                        TestContext.Properties["MyKey2"] = "My value 2 ...";
                        break;
                }
    
            }
            [TestMethod]
            public void MyTestMethod()
            {
                // Usage:
                // TestContext.Properties["MyKey"].ToString()
            }   
    
            [TestMethod]
            public void MyTestMethod2()
            {
                // Usage:
                // TestContext.Properties["MyKey"].ToString()
                // also has:
                // TestContext.Properties["MyKey2"].ToString()
            }
       
        }

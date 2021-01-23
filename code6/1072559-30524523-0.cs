    [TestInitialize()]
         public void MyTestInitialize() {
             driver = new InternetExplorerDriver();
             driver.Manage().Window.Maximize();
            
         }

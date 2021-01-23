            [TestCleanup]
            public void Clenup()
            {
                   ..............
            }
    
    
            [TestMethod]
            public void Test1()
            {
                try
                {...................}
                catch (Exception e)
                {
                     Cleanup();
                     throw new Exception();
                }
             }

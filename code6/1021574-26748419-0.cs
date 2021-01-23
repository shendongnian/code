        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Status;
            if(status != TestStatus.Passed)
              Console.WriteLine("Test Failed: {0}", TestContext.CurrentContext.Test.FullName);   
        }

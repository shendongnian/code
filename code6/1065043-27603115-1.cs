        [TestMethod]
        public void TestSomeMethod()
        {
            using (ShimsContext.Create())
            {
                ShimEnvironment.GetCommandLineArgs = () => new string[] { "arg1", "arg2" };
                // Your test here.
             }
        }

    [TestMethod]
    public void TestSomeMethod()
    {
        using (MolesContext.Create())
        {
            Moles.MEnvironment.GetCommandLineArgs = () => new string[] { "arg1", "arg2" };
            // Your test here.
         }
    }

    public void Setup([CallerMemberName] string method = null)
    {
         Type type = typeof(MyTestClass);
      	 MethodInfo info = type.GetMethod(name);
         CurrentTestCaseId = GetAttribute(info);
         Log.Info("Starting to execute Test Case ID: " +CurrentTestCaseId); 
    }
    [TestId("someID")]
    public void MyTest()
    {
        Setup(); //"method" should be automatically provided as "MyTest"
    }
    public TestIdAttribute GetAttribute(MethodInfo info)
    {
        return (TestIdAttribute)info.GetCustomAttributes(typeof(TestIdAttribute), false).First();
    }

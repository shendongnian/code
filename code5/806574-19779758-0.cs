    private void TestMethodWrapper(object param)
    {
       TestMethod1((bool)param);
    }
    public void TestMethod1(bool param)
    {
        var something = !param;
    }
    public void testMethod2()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(TestMethodWrapper), true);
    }

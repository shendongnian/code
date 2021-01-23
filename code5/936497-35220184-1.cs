    [TestMethod]
    public void TestMethod()
    {
        // arrange
        var app = Application.Launch(@"c:\ApplicationPath.exe");
        var targetWindow = app.GetWindow("Window1");
        Button button = targetWindow.Get<Button>("Button");
    
        // act
        button.Click();        
    
        var actual = GetMessageBox(targetWindow, "Application Error", 1000L);
    
        // assert
        Assert.IsNotNull(actual); // I want to see the messagebox appears.
        // Assert.IsNull(actual); // I don't want to see the messagebox apears.
    }
    
    private void GetMessageBox(Window targetWindow, string title, long timeOutInMillisecond)
    {
        Window window = null ;
    
        Thread t = new Thread(delegate()
        {
            window = targetWindow.MessageBox(title);
        });
        t.Start();
    
        long l = CurrentTimeMillis();
        while (CurrentTimeMillis() - l <= timeOutInMillsecond) { }
    
        if (window == null)
            t.Abort();
    
        return window;
    }
    
    public static class DateTimeUtil
    {
        private static DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long currentTimeMillis()
        {
            return (long)((DateTime.UtcNow - Jan1st1970).TotalMilliseconds);
        }
    }

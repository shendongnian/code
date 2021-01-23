    private void Application_Closing(object sender, ClosingEventArgs e)
    {
        var task = A.onEndApp();
        task.Wait();
    }
    async public static Task onEndApp()
    {
        string temp = await doSomething();
        //code here
    }

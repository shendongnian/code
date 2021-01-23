    [AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
        LongRunningTaskAsync();
        return View();
    }
    public static async Task LongRunningTaskAsync()
    {
        await Task.Run(() => LongRunningTask());
    }
    public static void LongRunningTask()
    {
        Debug.WriteLine("LongRunningTask started");
        Thread.Sleep(10000);
        Debug.WriteLine("LongRunningTask completed");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RunOnStaThread<object>(() =>
        {
            IE ie = new IE("http://localhost:5243/Addition.aspx");
            ie.TextField(Find.ByName("txtbox1")).TypeText("1");
            ie.TextField(Find.ByName("txtbox2")).TypeText("2");
            ie.Button(Find.ByValue("Calculate")).Click();
            return null;
        });
    }
    static T RunOnStaThread<T>(Func<T> func)
    {
        var tcs = new TaskCompletionSource<T>();
        var thread = new Thread(() => 
        {
            try
            {
                tcs.SetResult(func());
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        });
        thread.IsBackground = true;
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        try 
        {
            return tcs.Task.Result;
        }
        finally
        {
            thread.Join();
        }
    }

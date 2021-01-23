    void Main()
    {
        using (var fm = new Form())
        {
            var btn = new Button();
            fm.Controls.Add(btn);
            btn.Click += HandleClick;
    
            Thread.CurrentThread.ManagedThreadId.Dump("Main thread");
            fm.ShowDialog();
        }
    }
    
    public static void HandleClick(object sender, EventArgs e)
    {
        var synchronizationContext = SynchronizationContext.Current;
        var thread = new Thread(new ThreadStart(
            () => BackgroundMethod(synchronizationContext)));
        thread.Start();
    }
    
    public static void BackgroundMethod(SynchronizationContext context)
    {
        context.Post(state =>
        {
            Thread.CurrentThread.ManagedThreadId.Dump("Invoked thread");
        }, null);
    }

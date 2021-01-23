    public static void Main()
    {
        var ctx1 = SynchronizationContext.Current; // returns null
        var form = new Form();
        var ctx2 = SynchronizationContext.Current; // returns a WindowsFormsSyncContext
        form.ShowDialog();
        var ctx3 = SynchronizationContext.Current; // returns a SynchronizationContext
        
        worker.RunWorkerAsync(); // wrong context now
    }

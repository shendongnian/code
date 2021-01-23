    private System.Threading.CancellationTokenSource cts;
    private async void DoButton_Click(object sender, RoutedEventArgs e)
    {
        cts = new System.Threading.CancellationTokenSource();
        var class1 = new MyClass();
        try
        {
            var asyncOp = await class1.DoSomeTaskAsync().AsTask(cts.Token);
            System.Diagnostics.Debug.WriteLine(asyncOp);
        }
        catch (OperationCanceledException oce)
        {
            // I want to get here.
            System.Diagnostics.Debug.WriteLine(oce);
        }
    }

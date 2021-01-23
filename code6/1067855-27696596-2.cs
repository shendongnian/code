    private CancellationTokenSource tcs;
    private async void Process_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            this.tcs = new CancellationTokenSource();
            var results = await ProcessAsync(tcs.Token);
        
            System.Windows.MessageBox.Show("Done");
        }
        catch OperationCanceledException ex
        {
            System.Windows.MessageBox.Show("Canceled");
        }
        catch Exception ex
        {
            System.Windows.MessageBox.Show("Error");
        }
    }
    private async void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.tcs.Cancel();
    }
    private async Task<IEnumerable<string>> ProcessAsync(CancellationToken ct)
    {
        var tasks =
            from e in this.Employees
            where e.Select
            select this.DoSomethingWithThisEmployeee(e.LastName, e.FirstName, ct);
        return await Task.WhenAll(runningTasks);
    } 

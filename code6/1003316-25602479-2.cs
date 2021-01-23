    var argument=Tuple.Create(Desktop.IsChecked,geforce.IsChecked);
    worker2.RunWorkerAsync(argument);
    ...
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do not access the form's BackgroundWorker reference directly. 
        // Instead, use the reference provided by the sender parameter.
        BackgroundWorker bw = sender as BackgroundWorker;
        // Extract the argument. 
        var myArguments=(Tuple<bool,bool>)e.Argument;
        var desktopIsChecked = (bool)myArguments.Item1;
        var geforceIsChecked = (bool)myArguments.Item2;
        ...
    }

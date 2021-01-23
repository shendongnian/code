    Task.Factory.StartNew(()=>
    {
        // blah
    }
    .ContinueWith(task=>
    {
        Application.Current.Dispatcher.BeginInvoke(new Action(()=>
        {
            // yay, on the UI thread...
        }
    }

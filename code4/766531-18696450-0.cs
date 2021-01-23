    Task.Factory.StartNew(new Action(() =>
    {
        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = false;
    })).ContinueWith(new Action(() => DoFunction1)).ContinueWith(new Action(() =>
    {
        button1.Enabled = false;
        button2.Enabled = false;
        button3Enabled = false;
    })).ContinueWith(new Action(() => DoFunction2));

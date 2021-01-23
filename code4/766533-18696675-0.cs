    // not allowed on a non-gui thread.
    button1.Enabled = false;
    button2.Enabled = false;
    button3.Enabled = false;
    new Thread(() =>
    {
        DoFunction1();
        DoFunction2();
        // execute this on the gui thread. (winforms)
        this.Invoke(() =>
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        });
    }).Start();

    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    int[] foo()
    {
    
        do_something1();
    
        int[] some_value;
        bool doneWaiting = false;
    
        timer1.Interval = 1000;
        timer1.Tick += new EventHandler(delegate(object o, EventArgs ea)
        {
            if (browser.ReadyState == WebBrowserReadyState.Complete)
            {
                timer1.Stop();
                baa(some_value);
                doneWaiting = true;
            }
        });
        timer1.Start();
    
        while (!doneWaiting)
        {
            Application.DoEvents();
        }
    
        return some_value;
    }

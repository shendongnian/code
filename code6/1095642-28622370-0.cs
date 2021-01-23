     Thread dispatcherTimer2 = new Thread(() => dispatcherTimer2_Tick(null, null));
            dispatcherTimer2.Start();
     public void dispatcherTimer2_Tick(object sender, EventArgs e)
        {
            //code for function call autoreport();
            Thread.Sleep(new TimeSpan(0, 0, 30));
        }

        // Declare it in the constructor of the class
        int level = 0;
        Timer timer = new Timer
        timer.Interval = 1000;
        timer.Tick +=new EventHandler(timer_Tick);
        
    private void timer_Tick(object sender, EventArgs e)
    {
        timer.Stop();
        if (level == 0)
        {
            Label_OS_Result.Content = operatingSystem;
            Image_OS.Visibility = Visibility.Visible;
            ++level;
        }
        else if (level == 1)
        {
            Label_CPU_Result.Content = procName;
            Image_CPU.Visibility = Visibility.Visible;
            ++level;
        }
        else if (level > 1)
        {
            this.Cursor = Cursors.Default;
            return;
        }
        timer.Start();
    }
    private void RunTest()
    {
        clearTable();
    
        //System.Threading.Thread.Sleep(1000);
        timer.Start();
        this.Cursor = Cursors.Wait;
    }

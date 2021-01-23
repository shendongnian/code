    dispatcherTimer2.Tick += new EventHandler(dispatcherTimer2_Tick);
    dispatcherTimer2.Interval = TimeSpan.FromMilliseconds(100);
    dispatcherTimer2.Start();
    private void dispatcherTimer2_Tick(object sender, EventArgs e)
    {
        Process[] aProc = Process.GetProcessesByName("IExplore"); 
        if (aProc.Length == 0)
        {
           richTextBox3.Visibility = System.Windows.Visibility.Hidden;
           button1.Visibility = System.Windows.Visibility.Visible;
        }
        else
        {
           button1.Visibility = System.Windows.Visibility.Hidden;
           richTextBox3.Visibility = System.Windows.Visibility.Visible;
        }
    }

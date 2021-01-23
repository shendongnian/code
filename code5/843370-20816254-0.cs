     void worker_DoWork(object sender, DoWorkEventArgs e)
     {
        //Glorious time-consuming code that no longer blocks!
        while (Process.GetProcessesByName("notepad").Length == 0)
        {
            System.Threading.Thread.Sleep(1000);
        }
     }

    static void Main()
    {
        System.Threading.Mutex appMutex = new System.Threading.Mutex(true, "MyApplicationName", out exclusive);
        if (!exclusive)
        {
            MessageBox.Show("Another instance of My Program is already running.","MyApplicationName",MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
            return;
        }
        Application.Run(new frmMyAppMain());
        GC.KeepAlive(appMutex);
    }

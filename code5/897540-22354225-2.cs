    private void btnStartExecutable_Click(object sender, EventArgs e)
    {
       Process[] processName = Process.GetProcessesByName("InsertProcessNameHere");
       if (pname.Length == 0)
       {
           MessageBox.Show("Application isn't running yet.");
           //Start application here
           Process.Start("InsertProcessNameHere");
       }
       else
       {
           MessageBox.Show("Application is already running.");
           //Don't start application, since it has been started already
       }
    }

    private bool _isExternalAppRunning = false;
    private void myButton_Click(object sender, EventArgs e)
    {
       // If the external app is running, do nothing
       if (_isExternalAppRunning)
            return;
       // Keep track of the fact that our external app is running
       _isExternalAppRunning = true;
       myButton.Enabled = false;
       ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "someapplication.EXE";
            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch{// Log error.   
            }
        myButton.Enabled = true;// turn the button back on
        // Keep track of the fact that our external app is no longer running
        _isExternalAppRunning = false;
    }

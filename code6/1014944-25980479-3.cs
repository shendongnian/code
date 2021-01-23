    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        var button = sender as Button;
        if (button != null && string.Equals(button.Name, @"CloseButton"))
        {
            //FormClosing event raised by a user-created button action
        }
        else
        {
            //FormClosing event raised by program or the X in top right corner
            //Do cleanup work (stop threads and clean up unmanaged resources)
            if (_bw.Scanning)
            {
                _bw.Scanning = false;
                ClosePending = true;
                e.Cancel = true;
                return;
            }
    
            //Code to clean up unmanaged resources goes here (dummy code below)
            ApplicationLogger.Get.Log("Doing final cleanup work and exiting application...");
            MemoryHandler.Get.Dispose();
            ApplicationLogger.Get.Dispose();
        }
    }

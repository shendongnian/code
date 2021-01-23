    public void WPFAppResponse(string person)
    {
        returnResults = person;
        
        // check bool so that we only perform the pulse if needed
        if (waitOnShowWindow)
        {
            waitOnShowWindow = false;
            lock (this)
            {
                // Signal the waiting thread to continue
                System.Threading.Monitor.PulseAll(this);
            }
        }
        mainWindow.Hide();
    }

    bool ownsMutex = false;
    // NOTE: Local is the default namespace, so the name could be shortened to myApp
    Mutex myMutex = new Mutex(false, @"Local\myApp");
    try 
    {
        ownsMutex = myMutex.WaitOne(0)
    }
    catch (AbandonedMutexException)
    {
        ownsMutex = true;
    }
    
    if (!ownsMutex)
    {
        MessageBox.Show("myApp is already running!", "Multiple Instances");
        return;
    }
    else 
    {
        try 
        {
            Application.Run(new Form1());
        }
        finally 
        {
            myMutex.ReleaseMutex();
        }
    }

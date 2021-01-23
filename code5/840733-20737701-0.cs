    bool failed = false;
    do
    {
        try
        {
            // Call goes here
            failed = false;
        }
        catch (System.Runtime.InteropServices.COMException e)
        {
            failed = true;
        }
        System.Threading.Thread.Sleep(10);
    } while (failed);

    object closeLockObj = new object();
    public void Close()
    {
        try
        {
            lock (closeLockObj)
            {
    
                if (newLocationHandle != IntPtr.Zero){
                CloseHandle(newLocationHandle);
                newLocationHandle = IntPtr.Zero;
                }......
    
            }
        }
        catch (Exception excpt)
        {
        //stack trace
        }
    }

    protected void Enqueue()
    {
        try
        {
            Task.Run(() => Process());
        }
        catch (Exception ex)
        {
            // Logging code here (no issues)
        }
    }
    protected void Process()
    {
        try {
            Process2();
        }
        catch (Exception e)
        {
            // Logging code
        }
    }
    protected void Process2()
    {
                // Code that calls into offensive DLL
    }

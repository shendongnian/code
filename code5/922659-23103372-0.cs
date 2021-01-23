    public void tryLoop<T>(Delegate anyMethod, T[] arguments)
    {
        while (true)
        {                              // Could be replaced by timer timeout
            try
            {
                anyMethod.DynamicInvoke(arguments);
                break;
            }
            catch
            {
                System.Threading.Thread.Sleep(2000); // wait 2 seconds
            }
        }
    }

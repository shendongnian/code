    void SendKeysSlowly(string text)
    {
        foreach ( char s in text )
        {
            SendKeys(s); // Choose the appropriate send routine
            System.Threading.Thread.Sleep(50); // Milliseconds, adjust as needed
        }
    }

    void methodA()
    {
        using (SIDataContext db = new SIDataContext(_host.Config.ConnectionString))
        {
            if (looksForSomeData())
                raiseSomeEvents();
        }
    }

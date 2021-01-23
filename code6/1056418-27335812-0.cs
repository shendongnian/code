    readonly object o = new object();
    bool databaseUpdated;
    // user clicked the payment button
    void onClick()
    {
        databaseUpdated = false;
        StartStep1();
        StartStep2();
    }
    // completion routines for steps #1 and #2
    void stepOneDone()
    {
        lock (o)
        {
            // do the database update here...i.e. the code you posted for step #1
           databaseUpdated = true;
           Monitor.Pulse(o);
        }
    }
    void stepTwoDone()
    {
        lock (o)
        {
            while (!databaseUpdated)
            {
                Monitor.Wait(o);
            }
            // Process Facebook response here...i.e. the code you posted for step #2
        }
    }

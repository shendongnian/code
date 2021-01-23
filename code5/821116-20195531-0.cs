    var state = 0;
    while(state < 2)
    {
        try
        {
            if(state == 0)
            {
                CallWebService();
                state = 1;
            }
            if(state == 1)
            {
                PushData();
                state = 2;
            }
        }
        catch
        {
            // do something useful (log, decrement retry count, etc.)
        }
    }

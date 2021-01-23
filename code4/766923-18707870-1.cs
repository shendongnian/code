    // as is a type of cast. if Receipt is of type cast,
    // it will return an object and put it into accountUpdater
    // variable. If Receipt is not of that type, it will place null
    // into accountUpdater variable
    var accountUpdater = Receipt.Item as accountUpdater;
    if (accountUpdater != null)
    {
        // Do something with account updater here. E.g.
        Console.WriteLine(accountUpdater.SomeAccountUpdaterProperty);
    }
    var endOfDayResp = Receipt.Item as endOfDayRespType;
    if (endOfDayResp != null)
    {
        // Do something with endOfDayResp here
    }   
    var flexCache = Receipt.Item as flexCacheRespType;
    if (flexCache != null)
    {
        // Do something with flex cache here
    } 

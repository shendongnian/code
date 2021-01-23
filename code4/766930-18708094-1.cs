    Receipt.IfType<accountUpdater>(r => {
        Console.WriteLine(r.SomeAccountUpdaterProperty);
    });
    Receipt.IfType<endOfDayResp>(r => {
        //Do something with endOfDayResp here
    });
    Receipt.IfType<flexCacheResp>(r => {
        //Do something with flexCacheResp here
    });

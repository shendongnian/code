    Receipt.Item.IfType<accountUpdater>(r => {
        Console.WriteLine(r.SomeAccountUpdaterProperty);
    });
    Receipt.Item.IfType<endOfDayResp>(r => {
        //Do something with endOfDayResp here
    });
    Receipt.Item.IfType<flexCacheResp>(r => {
        //Do something with flexCacheResp here
    });

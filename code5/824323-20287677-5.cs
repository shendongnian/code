    // query on the GeciciServisId properties.
    var resultTek = tbl_EkTransfer.Where(x => x.GeciciServisId == 5);
    var resultTt = tbl_Transfer.Where(x => x.GeciciServisId == 5);
    // create a holding class
    var results = new List<TransferResult>();
    
    // add the resutls from first table
    results.AddRange(resultTek.Select(x => new TransferResult()
    {
        GeciciServisId = x.GeciciServisId,
        Adres = x.Adres,
        Semt = x.Semt,
        EkipID = x.EkipID
    }));
    // add the resutls from second table
    results.AddRange(resultTt.Select(x => new TransferResult()
    {
        GeciciServisId = x.GeciciServisId,
        Adres = x.Adres,
        Semt = x.Semt,
        EkipID = x.EkipID
    }));
    // now one row per joined result set
    foreach (var result in results.OrderBy(x => x.Adres))
    {
        var test1 = result.Adres; // etc
    }

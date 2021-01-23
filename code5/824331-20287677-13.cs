    // create a holding class collection
    var results = new List<TransferResult>();
    // add the results from first table
    results.AddRange(tbl_EkTransfer.Where(x => x.GeciciServisId == 5)
        .Select(x => new TransferResult()
    {
        GeciciServisId = x.GeciciServisId,
        Adres = x.Adres,
        Semt = x.Semt,
        EkipID = x.EkipID,
        SourceTable = "tbl_EkTransfer"
    }));
    // add the results from second table
    results.AddRange(tbl_Transfer.Where(x => x.GeciciServisId == 5)
        .Select(x => new TransferResult()
    {
        GeciciServisId = x.GeciciServisId,
        Adres = x.Adres,
        Semt = x.Semt,
        EkipID = x.EkipID,
        SourceTable = "tbl_Transfer"
    }));
    // now one row per joined result set
    foreach (var result in results.OrderBy(x => x.Adres))
    {
        var test1 = result.Adres; // etc
    }

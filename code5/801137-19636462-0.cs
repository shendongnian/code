    static void Main(string[] args)
    {
        ReceiptsItemCodeAnalysisContext db = new ReceiptsItemCodeAnalysisContext();
        var recon = db.Recons
            .AsNoTracking() // <---- add this
            .Where(r => r.Transacs.Where(t => t.ItemCodeDetails.Count > 0).Count() > 0)
            .OrderBy( r => r.ReconNum);
    //...

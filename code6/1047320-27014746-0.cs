    private Track Create_SetTrack(NewFormViewModel nfvm)
    {
        return db.Tracks.FirstOrDefault();
    }
    [HttpPost]
    public ActionResult Create(NewFormViewModel nfvm)
    {
        db = new dbconnection(connStr);
        Track track= Create_SetTrack(nfvm);
        ....
    

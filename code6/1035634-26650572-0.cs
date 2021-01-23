    var db = _dbFactory();
    public void Update() {
    try
    {
        db.BeginTransaction();
        foreach(item in itemlist)
        {
            db.Insert(item);
        }
        db.CompleteTransaction();
    }
    catch(Exception)
    {
        db.Transaction.Rollback();
    }

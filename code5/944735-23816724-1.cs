	[WebMethod]
    public CommandMessages GetDataLINQ()
    {
		MyRepository db = new MyRepository();
		return db.DeQueueTestProject();
    }

    [HttpPost]
    public ActionResult Details(int? id, ItemHeader itemHeader)
    {
        string test;
        DB db = new DB();
        Response.Write(db.UpdateHeader(itemHeader));
        Response.End();
        return null;
    }

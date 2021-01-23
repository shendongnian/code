    public ActionResult Details(int id = 0)
    {
        MyModel myModel = db.MyModel.Find(id);
        myModel.FileUrl = ""; // <-- resolve link;
        ...
    }

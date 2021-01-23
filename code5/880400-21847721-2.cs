    [HttpPost]  
    public ActionResult Contact(MyModel model)
    {
        DAL dal = new DAL();
        dal.DoSomeThings(model);
    }

    public ActionResult Create()
    {    
       MyModel myModel = new MyModel();
       myModel.MyItems = from q in tbl1.AsEnumerable()
        select new MyModel (q.ID, q.Name);
       return View(myModel);
    }

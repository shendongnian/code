    public ActionResult DisplayMyData()
    {
        MyModelType model = new MyModelType();
        DateTime createDateDBObject = //get the date from your database
 
        model.CreateDate = createDateDBObject.ToString("dd/MM/yyyy");
        //or, for setting the current date
        //model.CreateDate = DateTime.Now.ToString("dd/MM/yyyy");
            
        return View(model);  
    }

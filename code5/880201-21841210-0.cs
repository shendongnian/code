    public class MyViewModel 
    {
       public int? Id {get;set;}
       public string UserName {get;set;}
    }
    
    public ActionResult Show()
    {
        return View(new MyViewModel());
    }
    
    [HttpPost]
    public ActionResult Show(MyViewModel model)
    {
        return Content(string.format("{0} - {1}", model.Id, model.UserName));
    }

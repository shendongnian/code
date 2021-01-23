    //your default action
    public ActionResult Index()
    {
    return RedirectToAction("NewAction"); //Like Response.Redirect() in Asp.Net WebForm
    }
    
    //your new action
    public ActionResult NewAction()
    {
    //some code here
      return view();
    }

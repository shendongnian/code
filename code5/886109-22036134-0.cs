    private const string IndexAction = "Index";
    
    [ActionName(IndexAction)]
    public ActionResult Index(){
        //do stuff
    }
    public ActionResult Other(){
        // do stuff
        if(foo)
            return RedirectToAction(IndexAction);
        //don't foo
    }

    [GET("{name}")]
    public virtual ActionResult Index2(string name)
    {
        // call a service with the string name
        return View("Index");
    }
 

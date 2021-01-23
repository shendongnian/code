    [GET("{name}")]
    public virtual ActionResult Index(string name)
    {
        // call a service with the string name
        return View();
    }

    public ActionResult Index()
    {
        MyModel1 m = new MyModel1();
        m.email = "ramilu";
        m.email = "email";
        return View(m);
    }
    public ActionResult submit(MyModel1 m)
    {
        return null;
    }

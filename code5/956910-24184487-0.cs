    public ActionResult Index()
                {
                    TestClass t = new TestClass();
                   t.D = DateTime.Now.ToString("MM/dd/yyyy");
    
                    return View(t);
                }

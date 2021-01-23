    public ActionResult Index()
                {     
    TestClass t = new TestClass();
                string dt = DateTime.Now.ToString("MM/dd/yyyy");
                t.D = DateTime.ParseExact(dt, "d/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                return View(t);
    }

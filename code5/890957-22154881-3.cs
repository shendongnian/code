    public ActionResult Index() {
        String str;
        if (Monitor.TryEnter(_lockobject, TimeSpan.FromSeconds(5)))
        {
            str = dosomething();
            Monitor.Exit(_lockobject);
        }
        else str = "Took too long!";
        return View();
    }

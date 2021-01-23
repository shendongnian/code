    public ActionResult Index() {
        // IsUserAnEditor is a placeholder for a method to determine whether the user
        // is an editor based on whatever role technology you're using.
        MyModel model = new MyModel { IsEditor = IsUserAnEditor() }
        return View(model);
    }

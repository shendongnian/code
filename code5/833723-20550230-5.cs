    public ActionResult getDataAndDisplay (int bar)
    {
        //...
        return View("numbers", "show", new DataDisplayViewModel(){User = userInfo, RunOfNumbers = runOfNumbers});
    }

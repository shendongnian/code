    [HandleError(ExceptionType = typeof(ArgumentException), View = "MissingArgument")]
    public ActionResult Test(int id)
    {
        return View();
    }

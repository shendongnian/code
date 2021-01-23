    // Responds to /controller/testaction?line=sometext
    public ActionResult TestAction(string line)
    {
        return View();
    }
    // Responds to /controller/testaction?line=sometext&moretext=somemoretexthere
    public ActionResult TestAction(string line, string moretext)
    {
        return View();
    }

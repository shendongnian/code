    [HttpPost]
    public ActionResult RunAction(string userProgram)
    {
        //if needed, you can use the "userProgram" value to determine the UserProgram to pass
        UserProgram up = new UserProgram();
        Run(up);
        return true;
    }

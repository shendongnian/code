    public void populateTerm()
    {
        Term = "Test";    
        string script = string.Format("useTerm('{0}');", Term);
        ScriptManager.RegisterStartupScript(this, GetType(), "term", script, true);
    }

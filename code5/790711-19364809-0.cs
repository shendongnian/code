    public void ShowLoginPrompt()
    {
        LoginPromptViewModel lg = new LoginPromptViewModel();//This does happen
        var parentConductor = (Conductor)(lg.Parent);
        parentConductor.Activate(lg);
    }

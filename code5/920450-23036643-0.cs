    public void addOption(string optiontext, Action optionAction = null)
    {
        if (optionAction == null)
        {
            defaultOptionCall();
            // whatever else you need
            return;
        }
            
        // to run the action
        optionAction.Invoke();
    }

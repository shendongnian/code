    public delegate void defaultOption();
    private void defaultOptionCall() { }
    public void addOption(string optiontext, defaultOption optionAction = null)
    {
        defaultOption action = optionAction ?? defaultOptionCall;
        ...
    }

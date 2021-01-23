    public delegate void DefaultOption();
    private void DefaultOptionCall() { }
    public void AddOption(string optiontext, DefaultOption optionAction = null)
    {
        DefaultOption action = optionAction ?? DefaultOptionCall;
        ...
    }

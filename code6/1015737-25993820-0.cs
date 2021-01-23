    public ICommand pvToggleSelectMapCommand
    {
        get
        {
            return new CommandHandler((params) => pvToggleSelectMap(params), true);
        }
    }
...
    public void pvToggleSelectMap(object params) { ... }

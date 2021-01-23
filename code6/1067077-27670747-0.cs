    public MainPage()
    {
        PressedAdd = new Command(param => SaveNote());
    }
    public ICommand PressedAdd { get; private set; }

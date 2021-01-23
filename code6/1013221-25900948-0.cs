    // In the code-behind of a window...
    public static MyWindow Instance { get; private set; }
    public MyWindow()
    {
         Initialize();
         Instance = this;
    }
    
    // Somewhere else in your program...
    var someValue = MyWindow.Instance.SomeControl.Value;

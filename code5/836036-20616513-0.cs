    // class-scoped variable
    private List<Textbox> _boxen = new List<TextBox>();
    
    public MyFormDerp()
    {
        InitializeComponent();
        _boxen.Add(txtTesting1);
        // etc
        _boxen.Add(txtTesting13);
    }

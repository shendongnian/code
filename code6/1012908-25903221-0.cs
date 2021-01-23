    public Main()
    {
        InitializeComponent();
        //Works for panels, richtextboxes, 3rd party etc..
        Application.AddMessageFilter(new ScrollableControls(richTextBox1));
    }

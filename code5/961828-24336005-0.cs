    public BlankPage1()
    {
        this.InitializeComponent();
        HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
        e.Handled = true;
    }

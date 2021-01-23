    public Form1()
    {
        InitializeComponent();
        GameStart();
        // Wire up a handler for the KeyPress event
        this.KeyPress += KeyCheck;
    }
    private void KeyCheck(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            button1.PerformClick();
        }
    }

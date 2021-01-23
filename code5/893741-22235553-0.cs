    private bool toClear = false;
    public MainPage()
    {
        InitializeComponent();
        myTextBox.GotFocus += (s, e) =>
           {
             myTextBox.SelectionStart = 0;
             toClear = true;
           };
        myTextBox.KeyUp+=myTextBox_KeyUp;
    }
    private void myTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (toClear)
        {
            myTextBox.Text = myTextBox.Text.Substring(0, 1);
            myTextBox.SelectionStart = 1;
            toClear = false;
        }
    }

     public MainWindow()
    {
        InitializeComponent();
        foreach (Control tb in MyStackPanel.Children)
        {
            if (tb is TextBox)
            {
                TextBox tb1 = (TextBox)tb;
                tb1.GotFocus += TextBox_GotFocus;
                tb1.LostFocus += tb1_LostFocus;
            }
        }
    }

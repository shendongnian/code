    public Printer(string strTextBox)
    {
        InitializeComponent();
        label1.Text = strTextBox;
        if (label1.Text == Language.English)
        {
            UserControl111.Label_Option_Multi = "Please select an option:"; //Simple test
        }
    }

    public Form1()
    {
        InitializeComponent();
        statusCmb.Text = "All";
        advancedQueryCb.CheckedChangedEvent += (sender, e) => 
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.Checked)
            {
                // The checkbox has been checked, so you can perform the 
                // necessary logic here
            }
        };
    }

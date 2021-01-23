    public Form()
    {
        InitializeComponent();
        // subscribe double click event handler
        dataGrid.DoubleClick += txtHost_DoubleClick;
        // subscribe keypress event handler
        dataGrid.KeyPress += txtHost_KeyPress;
    }
    void dataGrid_KeyPress(object sender, KeyPressEventArgs e)
    {
        // check for Enter Key Press
        if (e.KeyCode == Keys.Enter)
        { 
            // Call the double click event handler
            dataGrid_DoubleClick(sender, e);
        }
    }
    void dataGrid_DoubleClick(object sender, EventArgs e)
    {
        // Your Code here to handle double click event
    }

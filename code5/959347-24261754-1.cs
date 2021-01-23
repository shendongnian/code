    public Form1()
    {
        InitializeComponent(); // <-
        if (operationalToolStripMenuItem.Checked == true)
            Burn_JED_UES.Enabled = false;
    }

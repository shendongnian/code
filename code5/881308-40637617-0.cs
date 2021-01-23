    public MainFrm()
    {
        InitializeComponent();
        
        var subFrm = new SubFrm();
        subFrm.TopLevel = false;
        subFrm.Dock = DockStyle.Fill;
        panelInTabPage.Controls.Add(subFrm);
        subFrm.Show();
    }

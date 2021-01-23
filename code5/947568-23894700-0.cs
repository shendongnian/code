    public bool EnabledtxtItemName { get; set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        txtItemName.Enabled = EnabledtxtItemName;
    }

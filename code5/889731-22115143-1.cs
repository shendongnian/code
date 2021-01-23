    public EmpPanel()
    {
        InitializeComponent();
        this.button1.Enabled = false;
        this.ControlBox = false;
        this.id1 = GetMaxEmpPanelId();
    }
    private int GetMaxEmpPanelId()
    {
        int maxId = 1000; //get max id from the related table and return it
        return maxId;
    }

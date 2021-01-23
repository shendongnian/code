    protected void Page_Load(object sender, EventArgs e)
    {
        MyMasterPage m = Master as MyMasterPage;
        string masterProperty = m.MyProperty;
    }

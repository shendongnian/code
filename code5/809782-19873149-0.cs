    protected void Page_Load(object sender, EventArgs e)
    {
        var cnt = new StateController();
        IEnumerable<StateInfo> lst = cnt.GetList(1);
        if (lst != null)
        {
            rptHostList.DataSource = lst;
        }
    }

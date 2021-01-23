    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (NavigationContext.QueryString.ContainsKey("wrkTbx"))
        {
            string wrkTbx = NavigationContext.QueryString["wrkTbx"];
            MessageBox.Show("wrkTbx value is: " + wrkTbx);
        }
        if (NavigationContext.QueryString.ContainsKey("rstTbx"))
        {
            string rstTbx = NavigationContext.QueryString["rstTbx"];
            MessageBox.Show("rstTbx value is: " + rstTbx);
        }
        if (NavigationContext.QueryString.ContainsKey("roundTbx"))
        {
            string roundTbx = NavigationContext.QueryString["roundTbx"];
            MessageBox.Show("roundTbx value is: " + roundTbx);
        }
    }

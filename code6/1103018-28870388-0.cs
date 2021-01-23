    protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.DataView dataView = (DataView)sourceProducts
                                                  .Select(DataSourceSelectArguments.Empty);
        count2.Text = dataView .Count.ToString();
    }

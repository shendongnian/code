    protected void btnDilSil_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        var img = (Control) sender;
        var item = (RepeaterItem) img.NamingContainer;
        int index = item.ItemIndex;
    }

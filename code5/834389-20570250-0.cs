    protected void catListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        Label catLabel = e.Item.FindControl("lblcat");
        Session["currentCatLabelText"] = catLabel.Text;
    }

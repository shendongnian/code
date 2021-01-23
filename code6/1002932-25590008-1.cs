    protected void rptMyRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        System.Data.DataRowView dataItem = e.Item.DataItem as System.Data.DataRowView;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TextBox txtMyTextBox = e.Item.FindControl("txtMyTextBox") as TextBox;
            txtMyTextBox.Text = dataItem.Row["Title"].ToString();
        }
    }

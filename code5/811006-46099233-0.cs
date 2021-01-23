    using System.Web.UI.HtmlControls;//HtmlSelect
    protected void SelectClients_Change(object sender, EventArgs e)
    {
        HtmlSelect HS = sender as HtmlSelect;
        ListItem SelectedItem = HS.Items[HS.SelectedIndex];
    }

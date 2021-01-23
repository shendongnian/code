    protected void ExpExcel_Click(object sender, EventArgs e)
    {
        foreach (GridColumn col in rgTest.MasterTableView.Columns)
        {
            col.Display = !(col.UniqueName.Contains("notes") || col.UniqueName.Contains("EditCommandColumn") || col.UniqueName.Contains("column1"));
        }
        List<Telerik.Web.UI.GridItem> items = rgTest.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.FilteringItem).ToList();
        foreach (GridFilteringItem item in items)
        {
            item.Visible = false;
            // Replace any space character with an underscore:
            if (item.OwnerTableView.DataKeyNames[0] == "notes")
            {
                var c = item.Controls[0] as System.Web.UI.WebControls.TextBox;
                if (c != null)
                {
                    c.Text.Replace(' ', '_');
                }
            }
        }
        rgTest.ExportSettings.ExportOnlyData = true;
        rgTest.MasterTableView.ExportToExcel();
    }

    // try this Put  Label2.Text = id; in   if (e.Item is TreeListDataItem)
    
    protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
    {
        string id = "";
        if (e.CommandName == "Select")
        {
            if (e.Item is TreeListDataItem)
            {
                TreeListDataItem item = e.Item as TreeListDataItem;
                 id = Convert.ToString(item.GetDataKeyValue("MessageID")) ;
                Label2.Text = id;
            }
        }
       
    }

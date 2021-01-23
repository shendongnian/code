    protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;
        string strID = item.GetDataKeyValue("ID").ToString(); //Using DataKey
        string strName1 = item["MyName"].Text; // Using BoundColumn UniqueName
        string strName2 = (item.FindControl("TextBox1") as TextBox).Text; // Using TemplateColumn Control
    }

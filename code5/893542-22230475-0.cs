    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
           string strId = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        }
    }

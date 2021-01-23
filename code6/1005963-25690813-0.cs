    protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        GridEditableItem item = e.Item as GridEditableItem;
        int Id = Convert.ToInt32(item.GetDataKeyValue("Id").ToString());
        //Access edit row ID value here -- using datakey
        string Name = (item["Name"].Controls[0] as TextBox).Text;
        // Get Name field updated value here
        int index = item.ItemIndex;
        // Access edit row index here
    }

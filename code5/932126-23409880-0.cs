    protected void Datalist1_EditCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("Edit"))
        {
                Response.Redirect(string.Format("EditArtikull3.aspx?id={0}",((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString()); // where [0] is the index of the column containing the item ID
        }
    }

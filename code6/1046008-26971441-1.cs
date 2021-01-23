    protected void gridDetaljiNarudzbe_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList drop =  e.Row.FindControl("DropDownList1") as DropDownList;
            drop.Items.Add(new ListItem("test"));
        }
    }

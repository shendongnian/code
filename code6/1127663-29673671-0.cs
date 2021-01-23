    protected void grdTenant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Style["display"] = "none";
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
             IDataRecord dataRow = (IDataRecord)e.Item.DataItem;
             txtRPCode.Text = Convert.ToString(dataRow["Retail Partner Code"]);
        }
    }

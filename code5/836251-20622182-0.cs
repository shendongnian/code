    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Data.DataRowView drv = e.Row.DataItem as System.Data.DataRowView;
            if (drv != null && Convert.IsDBNull(dRow["intBatchID"]))
                e.Row.Attributes.Add("ondblclick", String.Format("window.location='TestPage1.aspx?intBatchID={0}'", drv["intBatchID"]));
            e.Row.Attributes.Add("onMouseOver", "Highlight(this)");
            e.Row.Attributes.Add("onMouseOut", "UnHighlight(this)");
        }
    }

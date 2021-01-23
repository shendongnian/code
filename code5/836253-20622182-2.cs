    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var dr = e.Row.DataItem as Data.Common.DbDataRecord;
            if (dr != null && Convert.IsDBNull(dr["intBatchID"]))
                e.Row.Attributes.Add("ondblclick", String.Format("window.location='TestPage1.aspx?intBatchID={0}'", dr["intBatchID"]));
            e.Row.Attributes.Add("onMouseOver", "Highlight(this)");
            e.Row.Attributes.Add("onMouseOut", "UnHighlight(this)");
        }
    }

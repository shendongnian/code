    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var dr = e.Row.DataItem as Data.Common.DbDataRecord;
            if (dr != null && !Convert.IsDBNull(dr["intBatchID"]))
            {
                int intBatchId;
                int.TryParse(dr["intBatchID"], out intBatchId);
                if (intBatchId > 0)
                {
                    string js = "ChangeBatchId(" + intBatchId.ToString() + ");";
                    e.Row.Attributes.Add("ondblclick", js);
                }
            }
            e.Row.Attributes.Add("onMouseOver", "Highlight(this);");
            e.Row.Attributes.Add("onMouseOut", "UnHighlight(this);");
        }
    }

    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRoState.Alternate|DataControlRowState.Normal)
    {
             if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string script = ClientScript.GetPostBackClientHyperlink(this.gridViewTest,
                 "Edit$" + e.Row.RowIndex.ToString());
                e.Row.Attributes.Add("onclick", script);
            }
    }

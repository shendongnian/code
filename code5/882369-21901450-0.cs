    if(ds.Tables[0].Rows.Count==0)
    {
    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
    gvdata.DataSource = ds;
    gvdata.DataBind();
    int columncount = gvdata.Rows[0].Cells.Count;
    gvdata.Rows[0].Cells.Clear();
    gvdata.Rows[0].Cells.Add(new TableCell());
    gvdata.Rows[0].Cells[0].ColumnSpan = columncount;
    gvdata.Rows[0].Cells[0].Text = "No Records Found";
    }

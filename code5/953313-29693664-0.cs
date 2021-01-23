    int gvHasRows = grdResultados.Rows.Count;
    if (gvHasRows > 0)
    {
        grdResultados.Columns.Clear();
        grdResultados.DataBind();
    }

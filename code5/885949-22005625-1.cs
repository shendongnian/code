    for (int i = 0; i < gv_viewincident.Columns.Count; i++)
    {
    if (gv_viewincident.Columns[i].HeaderText == "Incident Number")
    {
    gv_viewincident.Columns[i].Visible = false;
    }
    }

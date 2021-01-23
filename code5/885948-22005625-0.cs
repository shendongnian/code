    for (int i = 0; i < gv_viewincident.Columns.Count; i++)
    {
    if (gv_viewincident.Columns[i].HeaderText == "IncidentNumber")
    {
    gv_viewincident.Columns[i].Visible = false;
    }
    }

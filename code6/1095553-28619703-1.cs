    dgv_Exhibitors.DataSource =
        DataAccess.ds.GL40200.AsEnumerable().Where(t => t.SGMTNUMB == 3).CopyToDataTable();
    foreach (var col in dgv_Exhibitors.Columns.Cast<DataGridViewColumn>()
                                      .Where(c => c.Name != "SGMNTID" && c.Name != "DSCRIPTN"))
    {
        col.Visible = false;
    }

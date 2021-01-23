    DataTable myTable = new DataTable();
    myTable.Columns.Add("SGMNTID", typeof(int));
    myTable.Columns.Add("DSCRIPTN", typeof(string));
    foreach (var x in query)
            {
                DataRow dr = myTable.NewRow();
                dr[0] = x.SGMNTID;
                dr[1] = x.DSCRIPTN;
                myTable.Rows.Add(dr);
            }
    dgv_Exhibitors.DataSource = myTable;

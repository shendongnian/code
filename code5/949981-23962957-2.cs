    DataTable dt1 = new DataTable();
    dt1.Columns.Add("ID", typeof (string));
    dt1.Rows.Add("1234-001");
    dt1.Rows.Add("1234-002");
    dt1.Rows.Add("1234-003");
    dt1.Rows.Add("5678-001");
    dt1.Rows.Add("7890-001");
    dt1.Rows.Add("7890-002");
    int i = 0;
    while (i < dt1.Rows.Count)
    {
        DataRow row = dt1.Rows[i];
        string key = row.Field<string>("ID").Split('-')[0];
        DataView dv = new DataView(dt1);
        dv.RowFilter = String.Format("ID LIKE '{0}*'", key.Replace("'", "''"));
        DataTable tempdt = dv.ToTable();
        i = i + tempdt.Rows.Count;
    }

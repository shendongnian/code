    Conn();
    int i = 0;
    cmd = new SqlCommand("select * from tbl_Emp", con);
    da = new SqlDataAdapter(cmd);
    dt = new DataTable();
    da.Fill(dt);
    if (dt != null && dt.Rows.Count > 0)
    {
    if (Dgv_Emp.Rows.Count > 0)
    { Dgv_Emp.Rows.Clear(); }
    Dgv_Emp.Rows.Add(dt.Rows.Count);
    foreach (DataRow rw in dt.Rows)
    {
    Dgv_Emp.Rows[i].Cells[0].Value = rw["Emp_id"].ToString();
    Dgv_Emp.Rows[i].Cells[1].Value = rw["Emp_name"].ToString();
    Dgv_Emp.Rows[i].Cells[2].Value = rw["Emp_desg"].ToString();
    Dgv_Emp.Rows[i].Cells[3].Value = rw["Emp_dept"].ToString();
    Dgv_Emp.Rows[i].Cells[4].Value = rw["Emp_gender"].ToString();
    Dgv_Emp.Rows[i].Cells[5].Value = rw["Emp_contact"].ToString();
    i = i + 1;
    }
    }

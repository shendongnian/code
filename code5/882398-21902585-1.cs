    if (GridView1.DataSource == null)
        {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                DataRow dr = dt.NewRow();
                dr[0] = "";
                dt.Rows.Add(dr);
                GridView1.DataSource=dt;
                GridView1.DataBind();
        }

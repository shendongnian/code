     protected void btnEdit_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Empid", typeof(string));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Address", typeof(string));
        foreach (GridViewRow row in GridView1.Rows)
        {
            if ((row.FindControl("CheckBox1") as CheckBox).Checked)
            {
                DataRow dr = dt.NewRow();
                dr[0] = TextBox1.Text; 
                dr[1] = TextBox2.Text; 
                dr[2] = TextBox3.Text;
                dt.Rows.Add(dr); 
            }
            else
            {
                dt.Rows.Add(row);
            }
        }
        GridView1.DataSource = dt;
        GridViewl.DataBind();
    }

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
                dt.Rows.Add(TextBox1.Text, TextBox2.Text, TextBox3.Text);
            }
            else
            {
                dt.Rows.Add(row);
            }
        }
        GridView1.DataSource = dt;
        GridViewl.DataBind();
    }

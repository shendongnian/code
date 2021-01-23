     protected void btnEdit_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();        
        foreach (GridViewRow row in GridView1.Rows)
        {
            if ((row.FindControl("CheckBox1") as CheckBox).Checked)
            {
                DataRow dr = dt.NewRow();
                dt[0] = TextBox1.Text; 
                dt[1] = TextBox2.Text; 
                dt[2] = TextBox3.Text;
                dt.Rows.Add(NewRow); 
            }
            else
            {
                dt.Rows.Add(row);
            }
        }
        GridView1.DataSource = dt;
        GridViewl.DataBind();
    }

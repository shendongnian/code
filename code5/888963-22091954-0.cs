    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb.Checked)
            {
                Label1.Text += "1";
            }
        }
    }

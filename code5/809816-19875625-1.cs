    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Selected item name:<br>";
        foreach (GridViewRow  item in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)item.FindControl("CheckBox1");
            if (chk != null)
            {
                if (chk.Checked)
                {
                    Label1.Text += item.Cells[1].Text + "<br>";
                }
            }
        }
    }

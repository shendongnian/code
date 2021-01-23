    protected void Button2_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow di in GridView1.Rows)
        {
            CheckBox chkId = (CheckBox)di.FindControl("CheckBox1");
            if (chkId != null)
            {
                if (chkId.Checked)
                {
                    string fileName = di.Cells[1].Text;
                    File.Delete(Server.MapPath("~/upload/" + TextBox1.Text + "/" + fileName));
                }
            }
        }
    }

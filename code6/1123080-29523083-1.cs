    protected void ButtonProcess_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)item.FindControl("CheckBoxProcess");
            if (chk != null)
            {
                if (chk.Checked)
                {
                    // This record should be processed
                }
            }
        }
    }

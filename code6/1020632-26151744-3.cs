    protected void Button2_Click(object sender, EventArgs e)
    {
        int userid = 0;
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox CheckBox1 = (CheckBox)gvrow.FindControl("chkSelect");
            if (CheckBox1.Checked)
            {
                userid = Convert.ToInt32(((HiddenField)gvrow.FindControl("hfdUserID")).Value);
                Response.Redirect("useredit.aspx?id=" + userid.ToString());
            }
        }
    }

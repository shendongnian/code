    protected void btnClick_Click(object sender, EventArgs e)
    { 
        StringBuilder sbQuery = new StringBuilder();
        bool flag = false;
        foreach (GridViewRow row in gridview1.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chk");
            if (((CheckBox)row.FindControl("chk")).Checked)
            {
                flag = true;
               //------
            }
        }
         
    }
 

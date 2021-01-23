    public void checkboxclear()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                If(row.RowType == DataControlRowType.DataRow)
                {
                   CheckBox chkrow = (CheckBox)row.FindControl("ChbGrid");
                if(chkrow.Checked)
                    chkrow.Checked = false;//it works 
                }
                else if(row.RowType == DataControlRowType.Header)
                {
                    CheckBox chkrow1 = (CheckBox)row.FindControl("ChbGridHead");
                    if (chkrow1.Checked)
                        chkrow1.Checked = false;
                 }
            }  
        } 

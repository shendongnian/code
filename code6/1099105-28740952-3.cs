    public void checkboxclear()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if(row.RowType == DataControlRowType.DataRow)
                {
                   CheckBox chkrow = (CheckBox)row.FindControl("ChbGrid");
                   if(chkrow.Checked)
                    chkrow.Checked = false;
                }
            }  
          CheckBox chkrow1 = (CheckBox)GridView1.HeaderRow.FindContro("ChbGridHead");
           if (chkrow1.Checked)
                chkrow1.Checked = false;
        } 

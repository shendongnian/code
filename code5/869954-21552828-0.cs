    for (int i = 0; i < GV.Rows.Count; i++)
            {
                GridViewRow row = GV.Rows[i];
                isChecked = ((CheckBox)row.FindControl("chkDelItem")).Checked;
                if (isChecked)
                {
                 //  delete
                }
             }

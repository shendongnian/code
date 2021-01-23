    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        // Cast the sender to a CheckBox type
        CheckBox chkAll = sender as CheckBox;
        // The as operator will return null if the cast is not successful,
        // so check for null before we try to use it
        if(chkAll != null)
        {
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in Repeateremail.Items)
                {
                    CheckBox chkSel =
                     (CheckBox)gvRow.FindControl("chkSelect");
                    chkSel.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow gvRow in Repeateremail.Items)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chkSelect");
                    chkSel.Checked = false;
                }
            }
        }
    }

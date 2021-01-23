    protected void YesOrNo_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSender = (CheckBox)sender;
        foreach (GridViewRow gvRow in gvwQueues.Rows)
        {
            if (gvRow.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkYes = (CheckBox)gvRow.FindControl("chkYes");
                CheckBox chkNo = (CheckBox)gvRow.FindControl("chkNo");
                if (chkSender.ClientID == chkYes.ClientID || chkSender.ClientID == chkNo.ClientID)
                {
                    int ItemId = Convert.ToInt32(gvwQueues.DataKeys[gvRow.RowIndex].Value);//here is the item number
                    if (chkNo.Checked)
                    {
                        chkYes.Checked = false;
                        //code to inactive
                    }
                    else if (chkYes.Checked)
                    {
                        chkNo.Checked = false;
                        //code to activate
                    }
                }
            }
        }
    }

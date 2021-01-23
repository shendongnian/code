    foreach (RepeaterItem ri in companyRepeater.Items)
    {
        CheckBox chkbox_All = ri.FindControl("foo") as CheckBox;
        if (chkbox_All != null)
        {
           if (!chkbox_All.Checked)
           {
               Response.Write("No checked");
           }
           else
           {
               var IDs = chkbox_All.ClientID;
               Response.Write("ID here...");
           }
        }
    }

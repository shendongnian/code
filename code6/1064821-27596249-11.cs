    foreach (RepeaterItem ri in companyRepeater.Items)
    {
        CheckBox chkbox_All = ri.FindControl("foo") as CheckBox;
        if (chkbox_All != null)
        {
            if (chkbox_All.Checked)
            {
                HiddenField hdCompName = ri.FindControl("hdCompName") as HiddenField;
                ltChecked.Text += hdCompName.Value;
                ltChecked.Text += ", ";
            }
        }
    }

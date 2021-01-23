    protected void chkDynamic_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox lb = (CheckBox)sender;
        if (lb.Checked)
        {
            ((TextBox)lb.Parent.FindControl("elective" + lb.ID.Replace("chk_", string.Empty))).Enabled = true;
        }
    }

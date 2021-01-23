    protected void chkDynamic_CheckedChanged (object sender, EventArgs e)
    {
        CheckBox lb = (CheckBox)sender;
        if (lb.Checked)
        {
            (FindControl(
                "elective" + System.Text.RegularExpressions.Regex.Match(
                    lb.ID, 
                    @"(\d+)(?!.*\d)").ToString()) 
                as System.Web.UI.WebControls.WebControl)
            .Enabled = true;
        }
    }

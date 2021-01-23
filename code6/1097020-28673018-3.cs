    protected void chkDynamic_CheckedChanged (object sender, EventArgs e)
    {
        CheckBox lb = (CheckBox)sender;
        if (lb.Checked)
        {
            (Page.FindControlRecursive(
                "elective" + System.Text.RegularExpressions.Regex.Match(
                    lb.ID, 
                    @"(\d+)(?!.*\d)").ToString()) 
                as System.Web.UI.WebControls.WebControl)
            .Enabled = true;
        }
    }
    public static Control FindControlRecursive(this Control Root, string Id)
    {
        if (Root.ID == Id)
        {
            return Root;
        }
        foreach (Control Ctl in Root.Controls)
        {
            Control FoundCtl = FindControlRecursive(Ctl, Id);
            if (FoundCtl != null)
            {
                return FoundCtl;
            }
        }
        return null;
    }

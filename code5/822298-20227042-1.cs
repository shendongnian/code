    void SomeFunctionName(object sender, RepeaterItemEventArgs e)
    {
        Checkbox chkbox_A = (Checkbox)e.Item.FindControl("chkModel_A");
        Checkbox chkbox_B = (Checkbox)e.Item.FindControl("chkModel_B");
        Checkbox chkbox_C = (Checkbox)e.Item.FindControl("chkModel_C");
        // Use or manipulate chkbox_A, chkbox_B, chkbox_C as per your requirements...
    }

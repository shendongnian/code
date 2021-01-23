    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {
            Page.Validate("vg1");
            ValidationSummary1.ValidationGroup = "vg1";
        }
        else if (RadioButton2.Checked)
        {
            Page.Validate("vg2");
            ValidationSummary1.ValidationGroup = "vg2";
        }
        
        if (Page.IsValid)
        {
            //do something in here
        }
    }

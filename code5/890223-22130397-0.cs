    protected void btnNext_Click(object sender, EventArgs e)
    {
        bool isVGLinRValid = false;
        bool isVGLogRValid = false;
        //Following two lines may not be required unless you want to force server side validation for security reasons
        //ASPX button already validated it before reaching this code.
        Page.Validate("vgLinR");
        isVGLinRValid = Page.IsValid;
        Page.Validate("vgLogR");
        isVGLinRValid = Page.IsValid;
        //check if both the validation groups have valid data
        if (isVGLinRValid == true && isVGLogRValid == true)
        {
            //do something in here
        }
    }

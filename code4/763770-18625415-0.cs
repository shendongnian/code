    if(!Page.IsValid && !myRangeValidator.IsValid)
    {
        // simplified, you will need to search for the control in the whole hierarchy
        var ctrlToValidate = Page.FindControl(myRangeValidator.ControlToValidate) as WebControl;
        if(ctrlToValidate != null)
        {
            ctrlToValidate.BorderColor = Color.Red;
        }
    }

    protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CompareValidatorInputTextBox1.Validate();
        CompareValidatorInputTextBox2.Validate();
        if (CompareValidatorInputTextBox1.IsValid && CompareValidatorInputTextBox2.IsValid) 
        {
            foo();
            blah();
        }
    }

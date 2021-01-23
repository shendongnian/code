    protected void validateCheckBoxes_ServerValidate(object sender, ServerValidateEventArgs e) 
    { 
    e.IsValid = RadioButton1.Checked || RadioButton2.Checked || RadioButton3.Checked || RadioButton4.Checked;
    if(e.IsValid)
    {
    // at least any one radio button is checked among all group
    }
    else
    {
    // no radio button is checked among all group
    } 

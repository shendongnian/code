    if (Model.MyCheckBox.Checked)
    {
       ModelState.Remove("CheckboxName");
    }
    
    if(ModelState.IsValid)
    {
       //Do stuff...
    }

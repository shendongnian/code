    InchMm_Conversion(StartMenuForm form)
    {
        myForm = form;    
    }
    private void InchMm_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
    {
        myForm.enableB();
    }
    private StartMenuForm myForm;
 

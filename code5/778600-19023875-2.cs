    protected void valeEmailAddress_txtEmailAddressValidate(object sender,
                                                          ServerValidateEventArgs e)
                {
                  string MaximumValue="09/25/2013";
                  string MinimumValue="1/1/2012";
                   // check for first condition
                 if(txtTravelerDOB >MaximumValue ||txtTravelerDOB < MinimumValue )
                 {
                   
                   // sample code here
                  // if failing, set IsValid to false
                     e.IsValid = false; 
                     // dynamically set the error message as per first condition
                     valxTextBox.ErrorMessage ="Not a valid date";  
                  }
                  
                 // check for second condition
                 // read the expression pattern from appSettings
                 if(!Regex.Match(txtTravelerDOB.Text.Trim(),
                    WebConfigurationManager.AppSettings("travelerDOBRegEX")).Success)
                {
                  // if fails, 
                     e.IsValid = false;
                     valxTextBox.ErrorMessage ="Format is Invalid";  
                }
    }

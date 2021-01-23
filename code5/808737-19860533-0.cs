    private void ValidateAndSave()
    {
        //Check for validation errors
        if ((this.Details.ValidationResults.HasErrors == false)) {
            //Save the changes to the database
            try {
                this.DataWorkspace.DatabaseNameData.SaveChanges();
            } catch (Exception ex) {
                this.ShowMessageBox(ex.ToString());
            }
        } else {
            //If validation errors exist,
            string res = "";
            //Add each one to a string,
            foreach (object msg_loopVariable in this.Details.ValidationResults) {
                msg = msg_loopVariable;
                res = res + msg.Property.DisplayName + ": " + msg.Message + "\r\n";
            }
    
            //And display them in a message box
            this.ShowMessageBox(res, "Validation error", MessageBoxOption.Ok);
        }
    }

    protected void results_BtnClick(object sender, GridViewCommandEventArgs e)
    {                
        if (e.CommandName == "del")
        {
            // Get the hidden field control from the current row
            var theHiddenField = e.Row.FindControl("HiddenFieldId") as HiddenField;
            // The as operator will return null for an unsuccessful cast
            // so check if we have something before we try to use it
            if(theHiddenField != null)
            {
                // Get the ID value
                var theId = Convert.ToInt32(theHiddenField.Value);
                // Do delete with ID value
                ...
            }
        }
    }

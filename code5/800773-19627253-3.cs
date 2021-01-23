      using (new Sitecore.SecurityModel.SecurityDisabler())
     {
        item.Editing.BeginEdit();
        try
        {
            //Value is updated here from "" to Test
            item.Fields["Content"].Value = "Test";
        }
        finally
        {
            //item.Fields["Content"].Value is "" again. 
           // Remove AcceptChanges I never use it , for editing . 
          //  item.Editing.AcceptChanges();
            item.Editing.EndEdit();
        }                 
    }
    

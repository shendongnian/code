    protected void grdView_OnRowCommand (object sender, EventArgs e)
    { 
           string part = button.CommandArgument;   
               int rowIndex = Int32.Parse(part);
              CheckBox chk= null;
              if (rowIndex != -1)
                {
                   chk= (CheckBox   )gvAlertSummary.Rows[rowIndex].Cells[0].FindControl("chkBox");
                    // Write your logic here
     } 
    }

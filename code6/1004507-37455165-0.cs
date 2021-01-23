     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          if (e.CommandName == "Select")
          {
            //Do something else
          }
          else if (e.CommandName == "View Cert")
          {
            //The hidden field id is hdnProgramId
            HiddenField hdnProgramId = (((e.CommandSource as LinkButton).Parent.FindControl("hdnProgramId")) as HiddenField);
          }
    
       }

    void UserDetails_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
      if(e.CommandName=="Details")
      {
    	Session["SelectedContact"]=e.CommandArgument;
            Response.Redirect("ViewContact1.aspx");
      }
      }

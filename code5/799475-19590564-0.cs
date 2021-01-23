    protected void tbMain_ActiveTabChanged(object sender, EventArgs e)
    {
        try
        {
            if (TabContainer1.ActiveTabIndex == 1)
            {
                Response.Redirect("~/WebForm1.aspx")
            }
    
            if (TabContainer1.ActiveTabIndex == 2)
            {
               Response.Redirect("~/WebForm2.aspx")
            }                
        }
        catch (Exception ex)
        {
            Support.ExceptionHandler.HandleException(ex);
        }
      }

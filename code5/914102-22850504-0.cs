    // this snippet checks if any of your Session variables have become null.
    // they would have been failing the ToString() check.
    
    Debug.Assert(Session["txtFirstName"] != null);
    Debug.Assert(Session["txtLastName"] != null);
    Debug.Assert(Session["txtPayRate"] != null);
    Debug.Assert(Session["txtStartDate"] != null);
    Debug.Assert(Session["txtEndDate"] != null);
    
    // Sends data to SavePersonel() to write to personnel table
    if (clsDataLayer.SavePersonnel(Server.MapPath("~/App_Data/PayrollSystem_DB.mdb"),
                                       Session["txtFirstName"].ToString(),
                                       Session["txtLastName"].ToString(),
                                       Session["txtPayRate"].ToString(),
                                       Session["txtStartDate"].ToString(),
                                       Session["txtEndDate"].ToString()))
    {
      txtVerifiedInfo.Text = txtVerifiedInfo.Text + "\nThe information was successfully saved!";
    }
    else
    {
      txtVerifiedInfo.Text = txtVerifiedInfo.Text + "\nThe information was NOT saved.";
    }

    if(Request["txtFirstName"].ToString().Trim() == "")
    {
        txtFirstName.BackColor = System.Drawing.Color.Yellow;
        string errorMessage;
        errorMessage + "First Name may not be empty.";
        OK = false;
    }

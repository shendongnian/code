    string errorMessage = "";
    // ...
  
    if(Request["txtFirstName"].ToString().Trim() == "")
    {
        txtFirstName.BackColor = System.Drawing.Color.Yellow;
        string errorMessage; 
        // ...

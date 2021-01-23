    if (userEmail != null)
    {
        //If the same email exists
        pnlError.Visible = Visible;
        var lblError= ((Label)(pnlError.FindControl("lblError")));
        if(lblError != null)
        {
            lblError.Text = "Error: The email you have entered......";
        }
    }

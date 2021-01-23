    // check if session security level is A
    if (Session["SecurityLevel"] == "A")
    {
        btnSubmit.Visible = true;
        //else, set submit button to not visible
    }
    else {
        btnSubmit.Visible = false;
    }

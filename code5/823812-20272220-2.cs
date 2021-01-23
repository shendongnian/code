    ///...
    string emailId = ((Label)Repeater2.Items[i].FindControl("YourEamil")).Text;
    //...
    string emailID = String.Empty;
    //...
    if (emailId.ToString() != "")
    {
        emailID = emailId.ToString();
    }
    else
    {
        emailID = "Unavailable";
    }

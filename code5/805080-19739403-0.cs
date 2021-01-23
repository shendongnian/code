    string lastCustId = "none";
    foreach (DataRow row in table.Rows)
    {
        if (!lastCustId.Equals("none") && !row["CustId"].ToString().Equals(lastCustId))
	    {
            // Different customer's record, fire off the email to previous one
            SendHtmlFormattedEmail("Email", "Subject", body.ToString());
            lastCustId = row["CustId"].ToString();
	    }
        // Build email for current customer
        CustFName = row["CustFName"].ToString();
        CustLName = row["CustLName"].ToString();
        CheckoutDate = row["CheckoutDate"].ToString();
        DueDate = row["DueDate"].ToString();
        BookName = row["BookName"].ToString();          
        body.AppendLine(PopulateBody(CustFName, CustLName, CheckoutDate, DueDate, BookName, template));
        // not sure what your template looks like, but this would be whatever
        // markup or text you would want separating your book details
        body.AppendLine("<br>");	    
    }
    // Finally send email to the last customer in above loop
    SendHtmlFormattedEmail("Email", "Subject", body.ToString());

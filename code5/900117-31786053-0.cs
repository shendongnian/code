    MailChimpManager mc = new MailChimpManager("API Key");
    EmailParameter emailParam = new EmailParameter()
    {
        Email = HttpUtility.HtmlEncode(email)
    };
    
    MergeVar mV = new MergeVar();
    mV.Add("FNAME", HttpUtility.HtmlEncode(firstName));
    mV.Add("LNAME", HttpUtility.HtmlEncode(lastName));
    EmailParameter results = mc.Subscribe("List ID", emailParam, mV);

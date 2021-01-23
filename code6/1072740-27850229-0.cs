    //Loading
    byte[] binary = Convert.FromBase64String(mailMergeTemplate.Attributes["body"].ToString());
    string bodyContent = UnicodeEncoding.UTF8.GetString(binary);
    
    //Storing
    byte[] bytes = UnicodeEncoding.UTF8.GetBytes(bodyContent);
    mailMergeTemplate.Attributes["body"] = Convert.ToBase64String(bytes);

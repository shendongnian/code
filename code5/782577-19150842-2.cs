    foreach (Outlook.Recipient r in oMsg.Recipients)
    {
        string username = getUserName(r.Name);//  or r.AddressEntry.Name instead of r.Name
        oMsg.HTMLBody += "<a href='C:\\Users\\" + username  + "'>Link</a>"
    }
    oMsg.Save();
    oMsg.Send();

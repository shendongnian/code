    bool send = false;
 
    if (!String.IsNullOrEmpty(mailMsg.To))
    {
         mailMessage.CC.Add(mailMsg.To);
         send = true;
    }
    if (!String.IsNullOrEmpty(mailMsg.CC))
    {
         mailMessage.CC.Add(mailMsg.Cc);
         send = true;
    }
    if (!String.IsNullOrEmpty(mailMsg.Bcc))
    {
         mailMessage.CC.Add(mailMsg.Bcc);
         send = true;
    }
    if (!send)
    {
         // what to do if none are set...
    }

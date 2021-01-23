    if (!String.IsNullOrEmpty(mailMsg.To))
    {
         mailMessage.CC.Add(mailMsg.To);
    }
    else if (!String.IsNullOrEmpty(mailMsg.CC))
    {
         mailMessage.CC.Add(mailMsg.Cc);
    }
    else if (!String.IsNullOrEmpty(mailMsg.Bcc))
    {
         mailMessage.CC.Add(mailMsg.Bcc);
    }
    else
    {
         // what to do if none are set...
    }

    using (var ic = new AE.Net.Mail.ImapClient("imap.gmail.com", "email", "pass", AE.Net.Mail.AuthMethods.Login, 993, true))
    {
        ic.SelectMailbox("INBOX");
        MailMessage[] mm = ic.GetMessages(0, 10);
        // at this point you can download the messages
    }

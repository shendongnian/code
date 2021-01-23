    public void check()
        {
            string sub;
            string result,from;
            int i = 1;
            do
            {
                ImapClient ic = new ImapClient("imap.mail.yahoo.com", "user@yahoo.com", "password", ImapClient.AuthMethods.Login, 993, true);
                ic.SelectMailbox("INBOX");
                int n = ic.GetMessageCount();
               
                MailMessage mail = ic.GetMessage(n - i);
                ic.Dispose();
                sub = mail.Subject;
                from = mail.From.ToString();
                result = mail.Raw;
                              
                i++;
            } while (sub != "subject" || from == "person@example.com");
            string mailmsg = result;
        }

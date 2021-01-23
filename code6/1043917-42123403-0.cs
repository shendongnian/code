    void SmtpSend(string from, string to, string subject, string body)
        {
            // \/ Use
            EASendMail.SmtpMail testMail = new EASendMail.SmtpMail("test");
            testMail.From = from;
            testMail.To = to;
            testMail.Subject = subject;
            testMail.TextBody = body;
            // Alternatively, you can use HTML bodies with testMail.HtmlBody = "<html><head></head><body></body>" etc. 
            // Just play around with it.
            // \/ Use the SmtpClient class to send your SmtpMail objects \/
            EASendMail.SmtpClient smtpClient = new EASendMail.SmtpClient();
            smtpClient.Credentials = new NetworkCredentials("username", "password");
            smtpClient.SendMail(testMail);
        }
        void main()
        {
            SmtpSend("sender@yourapp.com", "reciever@yourapp.com", "Test Mail", "Test Body");
        }

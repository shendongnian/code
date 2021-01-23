    public void MusicDownloadEmail(string email)
    {
        int tryAgain = 10;
        bool failed = false;
        do
        {
            try
            {
                failed = false;
    
                var smtp = new SmtpClient();
                var mail = new MailMessage();
                const string mailBody = "Body text";
                mail.To.Add(email);
                mail.Subject = "Mail subject";
                mail.Body = mailBody;
                mail.IsBodyHtml = true;
                smtp.Send(mail);
            }
            catch (Exception ex) // I would avoid catching all exceptions equally, but ymmv
            {                
                failed = true;
                tryAgain--;
                var exception = ex.Message.ToString();
                //Other code for saving exception message to a log.
            }
        }while(failed  && tryAgain !=0)
    }

    public static void MusicDownloadEmail(string email, int retryCountsLeft) {
            if (retryCountsLeft > 1) {
                try {
                    var smtp = new SmtpClient();
                    var mail = new MailMessage();
                    const string mailBody = "Body text";
                    mail.To.Add(email);
                    mail.Subject = "Mail subject";
                    mail.Body = mailBody;
                    mail.IsBodyHtml = true;
                    smtp.Send(mail);
                    
                } catch (Exception ex) {
                    var exception = ex.Message.ToString();
                    //Other code for saving exception message to a log.
                    MusicDownloadEmail(email, --retryCountsLeft);
                }
            }
        }

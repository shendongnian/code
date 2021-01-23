    public static bool ForgotPassword(string fromAccount, string toAccount, string subject, string msg)
        {
            var ConfirmationMail = new MailMessage();
            if (IsLiveMode)
            {
                ConfirmationMail = new MailMessage("abc@abc.com", toAccount, subject, msg);
            }
            else
            {
                ConfirmationMail = new MailMessage("abc@abc.com", toAccount, subject, msg);
                           }
             ConfirmationMail.Priority = MailPriority.High;
            ConfirmationMail.IsBodyHtml = true;
            SmtpClient objSMTPClient = new SmtpClient();
            try
            {
                objSMTPClient.Send(ConfirmationMail);
                return true;
            }
            catch
            {
                return false;
            }
        }

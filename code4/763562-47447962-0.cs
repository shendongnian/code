      //SendAsync
    public class MailHelper
    {
        
        public void SendMail(string mailfrom, string mailto, string body, string subject)
        {
            MailMessage MyMail = new MailMessage();
            MyMail.From = new MailAddress(mailfrom);
            MyMail.To.Add(mailto);
            MyMail.Subject = subject;
            MyMail.IsBodyHtml = true;
            MyMail.Body = body;
            MyMail.Priority = MailPriority.Normal;
            SmtpClient smtpMailObj = new SmtpClient();
            /*Setting*/
            object userState = MyMail;
            smtpMailObj.SendCompleted += new SendCompletedEventHandler(SmtpClient_OnCompleted);
            try
            {
                smtpMailObj.SendAsync(MyMail, userState);
            }
            catch (Exception ex) { /* exception handling code here */ }
        }
        public static void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Get the Original MailMessage object
            MailMessage mail = (MailMessage)e.UserState;
            //write out the subject
            string subject = mail.Subject;
            if (e.Cancelled)
            {
                Console.WriteLine("Send canceled for mail with subject [{0}].", subject);
            }
            if (e.Error != null)
            {
                Console.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message [{0}] sent.", subject);
            }
        }
        //
         
    }
    //SendMailAsync
    public class MailHelper
    {
        //
        public async Task<bool> SendMailAsync(string mailfrom, string mailto, string body, string subject)
        {
            MailMessage MyMail = new MailMessage();
            MyMail.From = new MailAddress(mailfrom);
            MyMail.To.Add(mailto);
            MyMail.Subject = subject;
            MyMail.IsBodyHtml = true;
            MyMail.Body = body;
            MyMail.Priority = MailPriority.Normal;
            using (SmtpClient smtpMailObj = new SmtpClient())
            {
                /*Setting*/
                try
                {
                    await smtpMailObj.SendMailAsync(MyMail);
                    return true;
                }
                catch (Exception ex) { /* exception handling code here */ return false; }
            }
        }
    }

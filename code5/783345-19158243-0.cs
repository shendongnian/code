    <system.net>
    	<mailSettings>
          <smtp from="emialid.com">
            <network host="domain.com" port="25" userName="emialid.com" password="******" defaultCredentials="false"/>
          </smtp>
        </mailSettings>
    	</system.net>
    public string SendEmailTest(String EmailMessage, String FromMail, String MailPassword, String MailServer, String To, String CC, String BCC, String DisplayName, String Subject, String Attachment)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                MailAddress fromAddress;
                fromAddress = new MailAddress(FromMail);
                smtpClient.Host = MailServer;
                smtpClient.Port = 25;
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(FromMail, MailPassword);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = SMTPUserInfo;
                message.From = fromAddress;
                message.To.Add(new MailAddress(To, DisplayName));
                if (CC != "")
                    message.CC.Add(new MailAddress(CC, DisplayName));
                if (BCC != "")
                    message.Bcc.Add(new MailAddress(BCC, DisplayName));
                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Body = "Your Password is : " + EmailMessage;
                if (Attachment != "")
                    message.Attachments.Add(new Attachment(Attachment));
                message.Priority = MailPriority.High;
                smtpClient.Send(message);
                return "SendEmail";
            }
            catch (Exception ex)
            {
                return "Email :" + ex;
            }
        }
    }
}

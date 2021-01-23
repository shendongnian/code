        namespace mysendemail
        {
         class Program
         {
          static void Main(string[] args)
          {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();
        
            // Set sender email address, please change it to yours
            oMail.From = "test@emailarchitect.net";
            
            // Set recipient email address, please change it to yours
            oMail.To = "support@emailarchitect.net";
            
            // Set email subject
            oMail.Subject = "test html email from C#";
            
            // Set Html body
            oMail.HtmlBody = "<font size=5>This is</font> <font color=red><b>a test</b></font>";
            // Your SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.emailarchitect.net");
            
            // User and password for ESMTP authentication, if your server doesn't require
            // User authentication, please remove the following codes.            
            oServer.User = "test@emailarchitect.net";
            oServer.Password = "testpassword";
            // If your smtp server requires SSL connection, please add this line
            // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
            try
            {
                Console.WriteLine("start to send HTML email ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }
    }
}

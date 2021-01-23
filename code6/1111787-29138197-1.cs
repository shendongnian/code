    using System;
    using System.IO;
    using System.Web;
    using System.Linq; 
    using System.Net.Mail;
    using System.Net.Mime;
    namespace OracleEntityFrameworkProject
    {
    class SendingEmail
    {
        static void Main(string[] args)
        {
            SendingEmail objProgram = new SendingEmail();
            string From = "your@gmail_id"; //change
            string To = ""; //change
            string[] Recepeint = { "abc@gmail.com;", "efg@gmail.com;", "hij@gmail.com;" };
            for (int i = 0; i < Recepeint.Length; i++) //change
			{//change
                To += Recepeint[i];//change
			}//change
                
            
            //string To = Convert.ToString(Recepeint);
            string Bcc = "klm@gmail.com";
            string Cc = "xyz@gmail.com";
            string Subject = "Test";
            string Body = "Hello... This is a Testing Message";
            string strDisplayName = "ABC";
            objProgram.fnSendMailMessage(From, To, Bcc, Cc, Subject, Body, strDisplayName);
            Console.ReadLine();
        }
        // To Send Mail To User
        private bool fnSendMailMessage(string From, string To, string Bcc, string Cc, string Subject, string Body, string strDisplayName = "")
        {
            try
            {
                // Instantiate a new instance of MailMessage 
                MailMessage mMailMessage = new MailMessage();
                // Set the sender address of the mail message
                mMailMessage.From = new MailAddress(From, strDisplayName);
                foreach (string strRecp in To.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries))//change
                {
                    // Set the recepient address of the mail message
                    mMailMessage.To.Add(new MailAddress(strRecp));
                }
                // Check if the bcc value is null or an empty string
                if ((!(Bcc == null) && (Bcc != String.Empty)))
                {
                    foreach (string strBcc in Bcc.Split(','))
                    {
                        // Set the Bcc address of the mail message
                        mMailMessage.Bcc.Add(new MailAddress(strBcc));
                    }
                }
                // Check if the cc value is null or an empty value
                if ((!(Cc == null) && (Cc != String.Empty)))
                {
                    foreach (string strCc in Cc.Split(','))
                    {
                        // Set the CC address of the mail message
                        mMailMessage.CC.Add(new MailAddress(strCc));
                    }
                }
                // Set the subject of the mail message
                mMailMessage.Subject = Subject;
                // Code to send Single attachments
                FileStream fs = new FileStream(@"D:\abc-xyz\abc\Links.txt", FileMode.Open, FileAccess.Read);
                Attachment a = new Attachment(fs, "Links.txt", MediaTypeNames.Application.Octet);
                mMailMessage.Attachments.Add(a);
                // Code to send Multiple attachments
                mMailMessage.Attachments.Add(new Attachment(@"C:\Users\abc\Desktop\SPS.txt"));
                mMailMessage.Attachments.Add(new Attachment(@"D:\abc-xyz\UseFull-Links\How to send an Email using C# – complete features.txt"));
                // Secify the format of the body as HTML
                mMailMessage.IsBodyHtml = true;
                //string path = (System.AppDomain.CurrentDomain + "ClientBin\\Images\\ELearningBanner.jpg");
                // To create an embedded image you will need to first create a Html formatted AlternateView. 
                // Within that alternate view you create an  tag, that points to the ContentId (CID) of the LinkedResource. 
                // You then create a LinkedResource object and add it to the AlternateView's LinkedResources collection.
                LinkedResource logo = new LinkedResource(@"C:\Users\abc\Desktop\Send\images.jpg", MediaTypeNames.Image.Jpeg); //It is mainly used for creating embedded images
                logo.ContentId = "Logo";
                AlternateView altView = AlternateView.CreateAlternateViewFromString(Body, null, MediaTypeNames.Text.Html);
                altView.LinkedResources.Add(logo);
                mMailMessage.AlternateViews.Add(altView);
                // Set the priority of the mail message to normal
                mMailMessage.Priority = MailPriority.Normal;
                // Instantiate a new instance of SmtpClient
                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Host = "smtp.gmail.com";
                mSmtpClient.EnableSsl = true;
                mSmtpClient.Credentials = new System.Net.NetworkCredential("Your_Id", "Your_Password");
                mSmtpClient.Port = 587;
                // Send the mail message
                mSmtpClient.Send(mMailMessage);
                Console.WriteLine("SuccessFully Sent");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Send" + ex);
                return false;
            }
        }
    }
}

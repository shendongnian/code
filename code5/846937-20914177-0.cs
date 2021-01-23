    using System;
    using System.Net;
    using System.Net.Mail;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                SendMail("smtp.gmail.com", "mymail@gmail.com", "myPassword", "yourmail@gmail.com", "e-mail subject", "body of the email", "data.xls");
            }
    
            public static void SendMail(string smtpServer, string from, string password, string mailto, 
                string caption, string message, string attachFile = null)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from);
                    mail.To.Add(new MailAddress(mailto));
                    mail.Subject = caption;
                    mail.Body = message;
    
                    if (!string.IsNullOrEmpty(attachFile))
                        mail.Attachments.Add(new Attachment(attachFile));
                    SmtpClient client = new SmtpClient();
                    client.Host = smtpServer;
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mail);
                    mail.Dispose();
                }
                catch (Exception e)
                {
                    throw new Exception("Mail.Send: " + e.Message);
                }
            }
        }
    }

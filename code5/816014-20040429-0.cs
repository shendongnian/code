    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Net.Mail;
    using System.Net;
    
    namespace SampleEMailSender
    {
        public class MailHelper
        {
    
            public void SendingEmail(string subject, string body) {
    
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add("<email to send>");
                mailMessage.From = new MailAddress("<email to use in sending>");
                mailMessage.Subject = subject; //the email subject
                mailMessage.Body = body; //the email body
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("<gmail account>", "<gmail password>");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(mailMessage);
            }
        }
    }

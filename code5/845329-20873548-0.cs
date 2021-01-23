    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
     
    /// <summary>
    /// Simple Emailer class for sending a simple email.
    /// </summary>
    public class Emailer
    {
        /// <summary>
        /// Takes a users email and item name and generates an email
        /// </summary>
        /// <param name="recipient">Recipients e-mail address</param>
        public static void SendMail(string recipient)
        {
            try
            {
                // Setup mail message
                MailMessage msg = new MailMessage();
                msg.Subject = "Email Subject";
                msg.Body = "Email Body";
                msg.From = new MailAddress("FROM Email Address");
                msg.To.Add(recipient);
                msg.IsBodyHtml = false; // Can be true or false
     
                // Setup SMTP client and send message
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587; // Gmail uses port 587
                    smtpClient.UseDefaultCredentials = false; // Must be set BEFORE Credentials below...
                    smtpClient.Credentials = new NetworkCredential("Gmail username", "Gmail Password");
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(msg);
                }
            }
            catch (SmtpFailedRecipientsException sfrEx)
            {
                // TODO: Handle exception
                // When email could not be delivered to all receipients.
                throw sfrEx;
            }
            catch (SmtpException sEx)
            {
                // TODO: Handle exception
                // When SMTP Client cannot complete Send operation.
                throw sEx;
            }
            catch (Exception ex)
            {
                // TODO: Handle exception
                // Any exception that may occur during the send process.
                throw ex;
            }
        }
    }

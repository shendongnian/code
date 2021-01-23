    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Mail;
    using System.Threading;
    using System.ComponentModel;
    using System.IO;
    using System.Net.Mime;
    
    
    namespace Invoice.WCFService
    {
        public class EmailSenser
        {
    
            public static bool SendEmail(string toMail, Stream stream, string mailBody)
            {
    
                bool sent = false;
    
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
    
                mail.From = new MailAddress("email@gmail.com");
                mail.To.Add(toMail);
                mail.Subject = "Invoice";
                //mail.Body = "Please, see attached file";
                mail.Body = mailBody;
    
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
    
                ContentType ct = new ContentType(MediaTypeNames.Application.Pdf);
    
                Attachment attachment = new Attachment(stream, ct);
                ContentDisposition disposition = attachment.ContentDisposition;
    
                disposition.FileName = DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";
    
                mail.Attachments.Add(attachment);
    
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("email@gmail.com", "password");
                SmtpServer.EnableSsl = true;
    
                try
                {
                    SmtpServer.Send(mail);
                    sent = true;
                }
                catch (Exception sendEx)
                {
                    System.Console.Write("Error: " + sendEx.Message.ToString());
                    sent = false;
                }
                finally
                {
                    //DBContext 
                }
                return sent;
            }
        }
    }

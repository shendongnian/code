    using System;
    using System.IO;
    using System.Text;
    using System.Net.Mail;
    using System.Security.Cryptography.Pkcs;
    using System.Security.Cryptography.X509Certificates;
    using System.Net;
    
    namespace EncryptedSMIME
    {
    
        class Program
        {
    
            static void Main(string[] args)
            {
                SendEncryptedEmail(@"C:\certificate.PFX", "email@email.com", "email@email.com", "Test C# Signed HTML EMail", "This email is signed.", "smtp.server.com", 25, false);
            }
    
    
    
            static void SendEncryptedEmail(string SigningCertPath, string To, string From, string Subject, string Body,string SmtpServer, int SmtpPort, bool HTML)
            {
                
                X509Certificate2 SignCert = new X509Certificate2(SigningCertPath, "password");
    
                StringBuilder Message = new StringBuilder();
    
                Message.AppendLine("Content-Type: text/" + ((HTML) ? "html" : "plain") +
    
                    "; charset=\"iso-8859-1\"");
    
                Message.AppendLine("Content-Transfer-Encoding: 7bit");
    
                Message.AppendLine();
    
                Message.AppendLine(Body);
    
                byte[] BodyBytes = Encoding.ASCII.GetBytes(Message.ToString());
    
    
                SignedCms Cms = new SignedCms(new ContentInfo(BodyBytes));
    
                CmsSigner Signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, SignCert);
    
                Cms.ComputeSignature(Signer);
    
                byte[] SignedBytes = Cms.Encode();
    
    
    
                MailMessage Msg = new MailMessage();
    
                Msg.To.Add(new MailAddress(To));
    
                Msg.From = new MailAddress(From);
    
                Msg.Subject = Subject;
    
    
    
                MemoryStream ms = new MemoryStream(SignedBytes);
    
                AlternateView av = new AlternateView(ms,
                    "application/pkcs7-mime; smime-type=signed-data;name=smime.p7m");
    
                Msg.AlternateViews.Add(av);
                SmtpClient smtp = new SmtpClient();
                smtp.Port = SmtpPort;
                smtp.Host = SmtpServer;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(From, "passwordFromYourEmail");
    
                smtp.Send(Msg);
                
               
                Console.ReadKey();
            }
    
        }
    
    }

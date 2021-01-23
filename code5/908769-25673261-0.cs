    using System;
    using System.IO;
    using System.Text;
    using System.Net.Mail;
    using System.Security.Cryptography.Pkcs;
    using System.Security.Cryptography.X509Certificates;
    
    namespace EncryptedSMIME
    
    {
    
       class Program
    
       {
    
           static void Main(string[] args)
    
           {
    
               SendEncryptedEmail("Cert.pfx", "thawte.cer",
    
                   "\"Noah Body\" ",
    
                   "\"John Doe\" ",
    
                   "Test C# Encrypted HTML EMail",
    
                   "This email is encrypted and signed.",
    
                   "smtp.singingeels.com", 25, false);
    
           }
    
    
    
           static void SendEncryptedEmail(
    
               string SigningCertPath, string EncryptingCertPath,
    
               string To, string From, string Subject, string Body,
    
               string SmtpServer, int SmtpPort, bool HTML)
    
           {
    
               X509Certificate2 SignCert = new X509Certificate2(SigningCertPath, "password");
    
               X509Certificate2 EncryptCert = new X509Certificate2(EncryptingCertPath, "");
    
    
    
               StringBuilder Message = new StringBuilder();
    
               Message.AppendLine("Content-Type: text/" + ((HTML) ? "html" : "plain") +
    
                   "; charset=\"iso-8859-1\"");
    
               Message.AppendLine("Content-Transfer-Encoding: 7bit");
    
               Message.AppendLine();
    
               Message.AppendLine(Body);
    
    
    
               byte[] BodyBytes = Encoding.ASCII.GetBytes(Message.ToString());
    
    
    
               EnvelopedCms ECms = new EnvelopedCms(new ContentInfo(BodyBytes));
    
               CmsRecipient Recipient = new CmsRecipient(
    
                   SubjectIdentifierType.IssuerAndSerialNumber, EncryptCert);
    
               ECms.Encrypt(Recipient);
    
               byte[] EncryptedBytes = ECms.Encode();
    
    
    
               SignedCms Cms = new SignedCms(new ContentInfo(EncryptedBytes));
    
               CmsSigner Signer = new CmsSigner
    
                   (SubjectIdentifierType.IssuerAndSerialNumber, SignCert);
    
    
    
               Cms.ComputeSignature(Signer);
    
               byte[] SignedBytes = Cms.Encode();
    
    
    
               MailMessage Msg = new MailMessage();
    
               Msg.To.Add(new MailAddress(To));
    
               Msg.From = new MailAddress(From);
    
               Msg.Subject = Subject;
    
    
    
               MemoryStream ms = new MemoryStream(EncryptedBytes);
    
               AlternateView av = new AlternateView(ms,
    
                   "application/pkcs7-mime; smime-type=signed-data;name=smime.p7m");
    
               Msg.AlternateViews.Add(av);
    
    
    
               SmtpClient smtp = new SmtpClient(SmtpServer, SmtpPort);
    
               smtp.UseDefaultCredentials = true;
    
               smtp.Send(Msg);
    
           }
    
       }
    
    }

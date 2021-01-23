    using System.Net;
    using System.Net.Mail;
    using System.Drawing;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Net.Configuration;
    private void Email(string email, string pass, string customername)
    {
         SmtpSection smtp = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
         MailMessage mm = new MailMessage(smtp.Network.UserName,email);
    
         mm.Subject = "Thank you for Registering with us";
         mm.Body = string.Format("Dear {0},<br /><br />Thank you for Registering with <b> Us. </b><br /> Your UserID is <b>{1}</b> and Password is <b> {2} </b> <br /><br /><br /><br /><br /><b>Thanks, <br />The Ismara Team </b>", customername, email, pass);            
         mm.IsBodyHtml = true;
    
       try
       {            
         using (SmtpClient client = new SmtpClient())
       {
          client.Send(mm);
       }
 
      }
    catch (Exception ex)
      {
         throw new Exception("Something went wrong while sending email !");                
       }
    }

        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Net.Mail;
        namespace sendmail
        {
          public partial class _Default : System.Web.UI.Page
          {
          protected void Page_Load(object sender, EventArgs e)
          {
          }
          protected void btnSubmit_Click(object sender, EventArgs e)
    
          {
    
           using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("mail@gmail.com");
                    mailMessage.Subject = txtSubject.Text.Trim();
                    mailMessage.Body = txtBody.Text.Trim();
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(txtTo.Text.Trim()));
                   
    
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = mailMessage.From.Address;
                    NetworkCred.Password = "<Password>";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mailMessage);
                }
         lblMsg.Text = "Email has been successfully sent..!!";
    
    
      }
    
    }
    
   } 

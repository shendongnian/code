    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Net;
    using System.Net.Mail;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            MailMessage mailMessage;
            SmtpClient smtpClient;
            try
            {
                mailMessage = new MailMessage();
                mailMessage.To.Add("013blitz@gmail.com");
                mailMessage.To.Add("crebrum.web.design@gmail.com");
                mailMessage.From = new MailAddress("crebrum.web.design@gmail.com");
                mailMessage.Subject = "Change your password";
                mailMessage.Body = "Hello Crebrum,\n\nPlease change your password for crebrum.web.design@gmail.com!" +
                    "You posted the password on stack overflow and anyone can access your email now.";
                smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                NetworkCredential nc = new NetworkCredential("crebrum.web.design@gmail.com", 
                    "{Here is where I masked your password. You are welcome}");
                smtpClient.Credentials = nc;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Send(mailMessage);
                //Response.Write("E-mail sent!");
            }
            catch (Exception ex)
            {
                //Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
        }
    }

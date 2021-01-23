    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Net.Mail;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage(txtFrom.Text, txtTo.Text, txtSubject.Text, txtBody.Text);
                SmtpClient emailClient = new SmtpClient(txtSMTPServer.Text);
                emailClient.Send(message);
                litStatus.Text = "Message Sent";
            }
            catch (Exception ex)
            {
                litStatus.Text=ex.ToString();
            }
        }
    }

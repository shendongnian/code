    public partial class Sendmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgSpinner.Attributes.Add("style", "display:none");
            if (IsPostBack)
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Send(new System.Net.Mail.MailMessage(txtFrom.Text, txtTo.Text));
            }
        }
    }

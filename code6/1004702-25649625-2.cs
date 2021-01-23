    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {    
            if (User.Identity.IsAuthenticated)
            {
                var sb = new StringBuilder();
                var id = (FormsIdentity) User.Identity;
                var ticket = id.Ticket;
                sb.Append("Authenticated");
                sb.Append("<br/>CookiePath: " + ticket.CookiePath);
                sb.Append("<br/>Expiration: " + ticket.Expiration);
                sb.Append("<br/>Expired: " + ticket.Expired);
                sb.Append("<br/>IsPersistent: " + ticket.IsPersistent);
                sb.Append("<br/>IssueDate: " + ticket.IssueDate);
                sb.Append("<br/>Name: " + ticket.Name);
                sb.Append("<br/>UserData: " + ticket.UserData);
                sb.Append("<br/>Version: " + ticket.Version);
                MessageLabel.Text = sb.ToString();
            }
            else
                MessageLabel.Text = "Not Authenticated";
        }
    }

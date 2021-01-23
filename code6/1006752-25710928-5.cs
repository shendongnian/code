    public class Message
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            var messages = new List<Message>();
            foreach (var grow in grvCustomers.Rows)
            {
                //by theway putting password like this in grid is a bad idea
                var email = grow.Cells[0].Text.Trim();
                var pwd = grow.Cells[1].Text.Trim();
                SendEmail(new Message { email = email, password = pwd });
            }
            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        lbltotalcount.Text = string.Empty;
    }
    private void SendEmail(Message message)
    {
        using (var smtpClient = new System.Net.Mail.SmtpClient())
        {
            using (var mailMessage = new System.Net.Mail.MailMessage())
            {
                    mailMessage.Subject = "Test send email";
                    mailMessage.From = new System.Net.Mail.MailAddress("account@domain.com");
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = GenerateMessage(message);
                    mailMessage.To.Add(message.email);
                    smtpClient.Host = "localhost";
                    smtpClient.Send(mailMessage);
                }
            }
        }
    
    private string GenerateMessage(Message message)
    {
        var sb = new StringBuilder();
        sb.Append("<b>Email: </b>");
        sb.Append(string.Format("<br> {0} <br>", message.email));
        sb.Append("<br>  " + message.password + "<br><br>");
        //.
        //.Rest of the stuff here
        //..
        return sb.ToString();
    }
}

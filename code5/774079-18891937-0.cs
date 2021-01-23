    protected void SendEmail_Click(object sender, EventArgs e) {
    
    MailMessage message = new MailMessage();
    message.From = new MailAddress(Email.Text);
     
    message.To.Add(new MailAddress("YourEmailAddress"));
    
    message.Subject = "New message from Web";
    message.Body = Message.Text;
     
    SmtpClient client = new SmtpClient();
    client.Send(message);
    
    }

    try 
    {
        MailAddress from = new MailAddress(txtFrom.Text);
        MailAddress to = new MailAddress(txtTo.Text);
        MailMessage message = new MailMessage(from, to);
        message.Subject = txtSubject.Text;
        message.Body = txtBody.Text;
        SmtpClient client = new SmtpClient("1.20.72.1");
        client.Send(message);
    }
    catch (Exception ex) 
    {
        msgLabel.Text = "Caught Exception." + ex;
    }

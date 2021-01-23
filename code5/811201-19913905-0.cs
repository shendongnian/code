    SmtpClient client = new SmtpClient();
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.EnableSsl = true;
    client.Host = "smtp.gmail.com";
    client.Port = 587;
 
    // setup Smtp authentication
    System.Net.NetworkCredential credentials = 
        new System.Net.NetworkCredential("your_account@gmail.com", "yourpassword");
    client.UseDefaultCredentials = false;
    client.Credentials = credentials;                
 
    MailMessage msg = new MailMessage();
    msg.From = new MailAddress("your_account@gmail.com");
    msg.To.Add(new MailAddress("destination_address@someserver.com"));
 
    msg.Subject = "This is a test Email subject";
    msg.IsBodyHtml = true;
    msg.Body = string.Format("<html><head></head><body><b>Test HTML Email</b></body>");
 
    try
    {
        client.Send(msg);
        lblMsg.Text = "Your message has been successfully sent.";
    }
    catch (Exception ex)
    {
        lblMsg.ForeColor = Color.Red;
        lblMsg.Text = "Error occured while sending your message." + ex.Message;
    }

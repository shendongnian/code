    SmtpClient client = new SmtpClient();
    client.Port = 25;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    // explicitly declare that you will be providing the credentials:
    client.UseDefaultCredentials = false;
    client.Credentials = new NetworkCredential("username", "password");
    client.Host = "hp132.hostpapa.com";
    email.Subject = "New IT Request";
    email.Body = Model.Description;

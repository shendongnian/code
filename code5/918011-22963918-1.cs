        ...
        MailMessage message = new MailMessage(from, to, subject, body);
        SmtpClient client = new SmtpClient(server, 587);
        client.EnableSsl = true;
        client.UseDefaultCredentials = false; // <--- NEW
        client.Credentials = new NetworkCredential("raddaouirami@gmail.com", "XXXXXXXXX");

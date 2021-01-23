    using (var client = new SmtpClient ()) {
        client.Connect ("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
    
        // use the access token as the password string
        client.Authenticate ("username@gmail.com", credential.Token.AccessToken);
    
        client.Send (message);
    
        client.Disconnect (true);
    }

    using (var client = new SmtpClient ()) {
        client.Connect ("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
    
        // use the access token
        var oauth2 = new SaslMechanismOAuth2 ("username@gmail.com", credential.Token.AccessToken);
        client.Authenticate (oauth2);
    
        client.Send (message);
    
        client.Disconnect (true);
    }

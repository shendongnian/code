    var message = FetchMessageFromImapServer ();
    
    // clear the Resent-* headers in case this message has already been Resent...
    message.ResentSender = null;
    message.ResentFrom.Clear ();
    message.ResentReplyTo.Clear ();
    message.ResentTo.Clear ();
    message.ResentCc.Clear ();
    message.ResentBcc.Clear ();
    
    // now add our own Resent-* headers...
    message.ResentFrom.Add (new MailboxAddress ("MyName", "username@example.com"));
    message.ResentReplyTo.Add (new MailboxAddress ("MyName", "username@example.com"));
    message.ResentTo.Add (new MailboxAddress ("John Smith", "john@smith.com"));
    message.ResentMessageId = MimeUtils.GenerateMessageId ();
    message.ResentDate = DateTimeOffset.Now;
    
    using (var client = new SmtpClient ()) {
        client.Connect ("smtp.example.com", 465, true);
        client.Authenticate ("username", "password");
    
        // The Send() method will use the Resent-From/To/Cc/Bcc headers if
        // they are present.
        client.Send (message);
    
        client.Disconnect (true);
    }

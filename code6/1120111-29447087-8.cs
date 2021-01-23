    var messageToForward = FetchMessageFromImapServer ();
    
    // construct a new message
    var message = new MimeMessage ();
    message.From.Add (new MailboxAddress ("MyName", "username@example.com"));
    message.ReplyTo.Add (new MailboxAddress ("MyName", "username@example.com"));
    message.To.Add (new MailboxAddress ("John Smith", "john@smith.com"));
    message.Subject = "FWD: " + messageToForward.Subject;
    // now to create our body...
    var builder = new BodyBuilder ();
    builder.TextBody = "Hey John,\r\n\r\nHere's that message I was telling you about...\r\n";
    builder.Attachments.Add (new MessagePart { Message = messageToForward });
    message.Body = builder.ToMessageBody ();
    
    using (var client = new SmtpClient ()) {
        client.Connect ("smtp.example.com", 465, true);
        client.Authenticate ("username", "password");
    
        client.Send (message);
    
        client.Disconnect (true);
    }

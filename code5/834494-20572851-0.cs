    var email = new MailMessage();
    using (var reader = new StreamReader(email.RawMessage())) 
    using (var writer = new StringWriter()) {
        while(true) {
            var line = reader.ReadLine();
            if (line == null) break; // EOF
    
            if (line != "") { 
                // Header line
                writer.WriteLine(line);
                continue;
            }
    
            // End of headers, insert bcc, read body, then bail
            writer.WriteLine("Bcc: " + email.Bcc.ToString()); // or however you want to format it
            writer.WriteLine("");
            writer.Write(reader.ReadToEnd());
            break;
        }
    
        var messageText = writer.ToString();
        // Do something with message text which now has Bcc: header
    }

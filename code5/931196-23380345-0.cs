     mail2.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "xxx.xx.xx.xxx"; // smtp host ip
            mail2.Subject = "Testing.";
            mail2.Body = "Hello";
            string html = "html";
            // here is example to user AlternateViews 
    
            mail2.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, new System.Net.Mime.ContentType("text/html"));
            string Plaintext ="plain text";
            mail2.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(Plaintext, new System.Net.Mime.ContentType("text/plain"));
            mail2.SubjectEncoding = System.Text.Encoding.UTF8;
            mail2.BodyEncoding = System.Text.Encoding.UTF8;
            client.Send(mail2);

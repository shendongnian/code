     string htmlBody = "<html><body><h1>Picture</h1><br><img src=\"cid:filename\"></body></html>";
     AlternateView avHtml = AlternateView.CreateAlternateViewFromString
        (htmlBody, null, MediaTypeNames.Text.Html);
     LinkedResource inline = new LinkedResource("filename.jpg", MediaTypeNames.Image.Jpeg);
     inline.ContentId = Guid.NewGuid().ToString();
     avHtml.LinkedResources.Add(inline);
     MailMessage mail = new MailMessage();
     mail.AlternateViews.Add(avHtml);
     Attachment att = new Attachment(filePath);
     att.ContentDisposition.Inline = true;
     mail.From = from_email;
     mail.To.Add(data.email);
     mail.Subject = "Client: " + data.client_id + " Has Sent You A Screenshot";
     mail.Body = String.Format(
                "<h3>Client: " + data.client_id + " Has Sent You A Screenshot</h3>" +
                @"<img src=""cid:{0}"" />", inline.ContentId);
     mail.IsBodyHtml = true;
     mail.Attachments.Add(att);

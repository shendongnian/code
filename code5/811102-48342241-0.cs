    public void SendMailExample(string emailAddressTo, string hexColour)
        {
            // Give the LinkedResource an ID which should be passed into the 'cid' of the <img> tag -
            var linkedResourceId = "mylogo";
            var sb = new StringBuilder("");
            sb.Append("<body><p>This is the HTML email body with img tag...<br /><br />");
            sb.Append($"<img src=\"cid:{linkedResourceId}\" width=\"100\" height=\"115.5\" alt=\"Logo\"/>");
            sb.Append("<p></body>");
            var emailBodyHtml = sb.ToString();
            var emailBodyPlain = "This is the plain text email body";
            using (var message = new MailMessage())
            using (var logoMemStream = new MemoryStream())
            using (var altViewHtml = AlternateView.CreateAlternateViewFromString(emailBodyHtml, null, System.Net.Mime.MediaTypeNames.Text.Html))
            using (var altViewPlainText = AlternateView.CreateAlternateViewFromString(emailBodyPlain, null, System.Net.Mime.MediaTypeNames.Text.Plain))
            using (var client = new System.Net.Mail.SmtpClient(_smtpServer)
            {
                Port = 25,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = false
            })
            {
                message.To.Add(emailAddressTo);
                message.From = new MailAddress(_emailAddressFrom);
                message.Subject = "This is the email subject";
                // Assume that GetLogo() just returns a Bitmap (for my particular problem I had to return a logo in a specified colour, hence the hexColour parameter!)
                Bitmap logoBitmap = GetLogo(hexColour);
                logoBitmap.Save(logoMemStream, System.Drawing.Imaging.ImageFormat.Png);
                logoMemStream.Position = 0;
                using (LinkedResource logoLinkedResource = new LinkedResource(logoMemStream))
                {
                    logoLinkedResource.ContentId = linkedResourceId;
                    logoLinkedResource.ContentType = new ContentType("image/png");
                    altViewHtml.LinkedResources.Add(logoLinkedResource);
                    message.AlternateViews.Add(altViewHtml);
                    message.AlternateViews.Add(altViewPlainText);
                    client.Send(message);
                }
            }
        }

            string subject = "Subject";
            string body = @"Image 1: <img src='src1'/> <br/> Image 2: <img src='src2'/> <br/> Some Other Content";
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("<FromAddress@mail.com>");
            mail.To.Add(new MailAddress("<ToAddress@mail.com>"));
            mail.Subject = subject;
            mail.Body = body;
            mail.Priority = MailPriority.Normal;
            string contentID1 = Guid.NewGuid().ToString().Replace("-", "");
            string contentID2 = Guid.NewGuid().ToString().Replace("-", "");
            body = body.Replace("src1", "cid:" + contentID1);
            body = body.Replace("src2", "cid:" + contentID2);
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            //path of image or stream
            LinkedResource imagelink1 = new LinkedResource(@"F:\Images\020817045614.png", "image/png");
            imagelink1.ContentId = contentID1;
            imagelink1.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            htmlView.LinkedResources.Add(imagelink1);
            LinkedResource imagelink2 = new LinkedResource(@"F:\Images\020817045837.png", "image/png");
            imagelink2.ContentId = contentID2;
            imagelink2.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            htmlView.LinkedResources.Add(imagelink2);
            mail.AlternateViews.Add(htmlView);
            using (SmtpClient smtpClient = new SmtpClient("<SMTPHostAddress>"))
            {
                smtpClient.Send(mail);
            }

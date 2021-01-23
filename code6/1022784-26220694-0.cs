                MailMessage message = new MailMessage("support@mxxx.com", user.EmailAddress);
                message.Bcc.Add("xxx@gmail.com");
                message.Bcc.Add("xxx@yahoo.com");
                message.Bcc.Add("xxx@hotmail.com");
                message.Subject = "Your \"mxxx.com\" password has been reset";
                message.ReplyToList.Add(new MailAddress("support@mxxx.com"));
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.Delay |
                                                      DeliveryNotificationOptions.OnSuccess;
                message.Sender = new MailAddress("support@mxxx.com");
                string htmlbody = "<html><body><p>Dear " + name + ":</p>" +
                "<p>Your password at \"mxxx.com\" has been reset to: " + newPassword + "</p>" +
                </body></html>";
                message.Body = htmlbody;
                message.IsBodyHtml = true;
                SmtpClient mailMan = new SmtpClient();
                mailMan.Send(message);

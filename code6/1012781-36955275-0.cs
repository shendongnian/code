                SendGridMessage myMessage = new SendGridMessage();
                myMessage.AddTo(email);
                myMessage.AddBcc("MyEmail@gmail.com");
                myMessage.AddBcc("EmailSender_CC@outlook.com");
                myMessage.From = new MailAddress("SenderEmail@outlook.com", "DriverPickup");
                //myMessage.Subject = "Email Template Test 15.";
                myMessage.Headers.Add("X-SMTPAPI", GetMessageHeaderForWelcome("MyEmail@Gmail.com", callBackUrl));
                myMessage.Html = string.Format(" ");
                // Create an Web transport for sending email.
                var transportWeb = new Web(SendGridApiKey);
                // Send the email, which returns an awaitable task.
                transportWeb.DeliverAsync(myMessage);

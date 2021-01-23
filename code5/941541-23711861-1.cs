        public static MailAddress from = new MailAddress("myAddress@gmail.com","Ramy Mohamed");
        string password = "balabala";
        var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from.Address, password)
            };
           using (var message = new MailMessage(from, SendToAddress.Text)
                    {
                        Subject = MySubjectText.Text,
                        Body = MyContentText.Text
                    })
                    {
                        smtp.Send(message);                        
                    }

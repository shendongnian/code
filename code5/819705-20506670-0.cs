        public bool SendMail() {
            var client = new SmtpClient("smtp.gmail.com", 587) {
                Credentials = new NetworkCredential("your email", "password"),
                EnableSsl = true
            };
                        
            MailMessage message = new MailMessage(
                new MailAddress("from email address"),
                new MailAddress("to email address")) {
                    Body = "This is a test e-mail message sent using SSL ",
                    Subject = "Test email with SSL and Credentials"
                };
            
            try {
                client.Send(message);
            } catch (Exception ex) {
                Console.WriteLine("Exception is:" + ex.ToString());
            }
            Console.WriteLine("Goodbye.");
            return false;
        }

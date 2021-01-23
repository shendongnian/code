        message.To.Add(new MailAddress("abc@abc.com));  // replace with valid value 
            message.From = new MailAddress("abc@abc.com", "Contact Form");
            message.Subject = Subject;
            message.Body = string.Format(NewBody);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "abc@gmail.com",  // replace with valid value
                    Password = "qwerty123456"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

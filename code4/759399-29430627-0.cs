            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("xx@gmail.com");
            mail.Sender = new MailAddress("xx@gmail.com");
            mail.To.Add("external@emailaddress");
            mail.IsBodyHtml = true;
            mail.Subject = "Email Sent";
            mail.Body = "Body content from";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("xx@gmail.com", "xx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            
            smtp.Timeout = 30000;
            try
            {
                smtp.Send(mail);
            }
            catch (SmtpException e)
            {
                textBox1.Text= e.Message;
            }

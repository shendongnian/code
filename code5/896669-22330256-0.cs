     try
        {
            using (System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage())
            {
                message.To.Add("to emailadress");
                message.Subject = "New Ticket Generated";
                message.From = new System.Net.Mail.MailAddress("from emailaddress");
                message.IsBodyHtml = true;
                message.Body = "This is message body";
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("yourEmailid", "yourpassword");
                smtp.Send(message);
                
            }
        }
        catch(Exception)
        {
            throw;
        }
    

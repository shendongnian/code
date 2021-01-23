            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress("eksamensprojekt2014.gmail.com");
                message.From = fromAddress;
                message.To.Add("gymjoy@hotmail.com");
                message.Subject = "Test";
                message.IsBodyHtml = true;
                message.Body = "Test";
                smtpClient.Host = "smtp.gmail.com";   // We use gmail as our smtp client
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("eksamensprojekt2014.gmail.com", "*********");
                smtpClient.Send(message);
                msg = "Successful<BR>";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

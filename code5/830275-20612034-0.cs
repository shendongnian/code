            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("xx@xx.com", "xxx");
            client.Port = 587;
            client.EnableSsl = true;
            MailMessage maili = new MailMessage();
            maili.Body = body;
            maili.Subject = subject;
            maili.IsBodyHtml = true;
            maili.From = new MailAddress("xx@xx.com");
            maili.To.Add("aa@aa.com");
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.Send(maili);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            maili.Dispose();

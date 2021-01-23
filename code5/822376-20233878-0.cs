     public string gmail_send()
        {
            using (MailMessage mailMessage =
            new MailMessage(new MailAddress(toemail),
        new MailAddress(toemail)))
            {
                mailMessage.Body = body;
                mailMessage.Subject = subject;
                try
                {
                    SmtpClient SmtpServer = new SmtpClient();
                    SmtpServer.Credentials =
                        new System.Net.NetworkCredential(email, password);
                    SmtpServer.Port = 587;
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.EnableSsl = true;
                    mail = new MailMessage();
                    String[] addr = toemail.Split(','); // toemail is a string which contains many email address separated by comma
                    mail.From = new MailAddress(email);
                    Byte i;
                    for (i = 0; i < addr.Length; i++)
                        mail.To.Add(addr[i]);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions =
                        DeliveryNotificationOptions.OnFailure;
                    //   mail.ReplyTo = new MailAddress(toemail);
                    mail.ReplyToList.Add(toemail);
                    SmtpServer.Send(mail);
                    return "Mail Sent";
                }
                catch (Exception ex)
                {
                    string exp = ex.ToString();
                    return "Mail Not Sent ... and ther error is " + exp;
                }
            }
        }

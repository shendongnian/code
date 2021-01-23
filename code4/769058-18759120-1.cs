    string toEmail = "reciever Email";
                    MailMessage message = new MailMessage();
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        var smtpSection = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as System.Net.Configuration.SmtpSection;
                        MailAddress fromAddress = new MailAddress(Convert.ToString(smtpSection.From), "Mail Header");
                        smtpClient.Host = Convert.ToString(smtpSection.Network.Host);
                        smtpClient.Port = Convert.ToInt32(smtpSection.Network.Port);
                        if (smtpSection.Network.UserName != null && smtpSection.Network.Password != null)
                        {
                            smtpClient.Credentials = new System.Net.NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                        }
                        message.From = fromAddress;
                        message.To.Add(toEmail);
                        message.Subject = "your subject";
                        message.Body = "message body";
                        message.IsBodyHtml = true; // if using html
                        message.BodyEncoding = Encoding.UTF8;
                        smtpClient.Send(message);
                    }

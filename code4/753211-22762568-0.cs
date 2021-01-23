                    try
                    {
                        var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
                        var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
                        var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
                        var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                        var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
                        string body = "Your registration has been done successfully. Thank you.";
                        MailMessage message = new MailMessage(
                                                new MailAddress(fromEmailAddress, fromEmailDisplayName),
                                                new MailAddress(ud.LoginId, ud.FullName));
                        message.Subject = "Thank You For Your Registration";
                        message.IsBodyHtml = true;
                        message.Body = body;
                        var client = new SmtpClient();
                        client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
                        client.Host = smtpHost;
                        client.EnableSsl = true;
                        client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        throw (new Exception("Mail send failed to loginId " + ud.LoginId + ", though registration done."));
                    }

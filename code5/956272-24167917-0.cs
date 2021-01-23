                    SmtpClient smtpmail = new SmtpClient();
                
                    smtpmail.Host = ConfigurationManager.AppSettings["host"];
                    smtpmail.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
                    smtpmail.EnableSsl = true;    
                    smtpmail.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpmail.UseDefaultCredentials = false;
                    smtpmail.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailFrom"], ConfigurationManager.AppSettings["Password"]);
                    MailMessage message = new MailMessage(ConfigurationManager.AppSettings["MailFrom"], MailTo, Subject, MessageTosend);
                    message.IsBodyHtml = true;

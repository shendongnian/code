            private void SendMail(string Address, string Body)
            {
                try
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.To.Add(Address);
                    mailMessage.Subject = "Your Subject";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = Body;
                    SmtpClient smtpClient = new SmtpClient(); // This will take the Credentioals from the WEB/APP Config 
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    Extention.Log(ex.Message + "/=> " + ex.StackTrace);
                }
            }

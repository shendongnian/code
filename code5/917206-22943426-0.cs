        private void SendMessage()
        {
            try
            {
                StringBuilder body = new StringBuilder();
                string[] messages = { "test this on line #1", "test line number 2", "This is test line three I think.." };
                foreach (var msg in messages)
                {
                    body.AppendLine(msg);
                    body.AppendLine(string.Empty);
                }
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress("you@test.com", "Your Display Name");
                    message.ReplyToList.Add("reply-email@test.com");
                    message.To.Add("thetoemail@test.com");
                    message.Subject = "Test Line Break Message";
                    message.IsBodyHtml = false;
                    message.Priority = MailPriority.Normal;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Body = body.ToString();
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        smtpClient.Send(message);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

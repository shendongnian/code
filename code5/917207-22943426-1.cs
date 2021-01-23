        private void SendMessage()
        {
            try
            {
                StringBuilder body = new StringBuilder();
                string[] messages = { "test with    a tab in it", "    test with     spaces", " \r\nTab, then line break", "\n\n\n\n\n\nlots of returns...", "                test spaces" };
                foreach (var msg in messages)
                {
                    body.AppendLine(msg);
                    //body.AppendLine(string.Empty);
                }
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress("you@test.com", "Your Display Name");
                    message.ReplyToList.Add("reply-email@test.com");
                    message.To.Add("to@test.com");
                    message.Subject = "Test Line Break Message";
                    message.IsBodyHtml = false;
                    message.Priority = MailPriority.Normal;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Body = body.ToString();
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        smtpClient.Host = "127.0.0.1";
                        smtpClient.Send(message);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

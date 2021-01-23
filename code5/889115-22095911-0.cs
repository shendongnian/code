     SendMessage Smessage = new SendMessage(ResultCallback);
                //smtp.Send(message);
                Smessage.BeginInvoke(smtpClient, message, null, null);
    public void ResultCallback(SmtpClient client, MailMessage m)
            {
                try
                {
                    client.Send(m);
                    client.Dispose();
                    m.Dispose();
                }
                catch
                {
    
                }
            }

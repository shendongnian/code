    async Task SendMail(ICollection<MailMessage> messages)
    {
        using (var client = new SmtpClient())
        {
            foreach (MailMessags m in messages)
            {
                try
                {
                    await client.SendAsync(m);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

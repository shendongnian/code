    public async Task Post()
    {
        await Task.WhenAll(
            SendEmail("a@b.com"),
            SendEmail("b@c.com")
        );
    }
    private async Task SendEmail(string to)
    {
        using (var client = new SmtpClient())
        {
            await Task.Delay(3000);
            
            await client.SendMailAsync(
                new MailMessage("test@test.com", to, "Test", "Test"));
        }
    }

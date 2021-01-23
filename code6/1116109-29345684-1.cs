    [Test]
    public void Test2()
    {
        MailData mailData = new MailData
        {
            HostAddress = "mydomain.com",
        };
    
        var mockSmtpClient = new MockSmtpClient();
        var mailerMock = new Mailer();
    
        // Act
        mailerMock.smtpClient = mockSmtpClient;
        mailerMock.SendMail(ref mailData);
        Console.WriteLine("SMTP CLIENT FROM TEST: " + mockSmtpClient);
        Console.WriteLine("SMTP HOST FROM TEST: " + mockSmtpClient.Host);
        Console.WriteLine("SMTP PORT FROM TEST: " + mockSmtpClient.Port);
    }

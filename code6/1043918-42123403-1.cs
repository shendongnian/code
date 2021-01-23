                SmtpServer smtpgm = new SmtpServer("smtp.gmail.com");
                EASendMail.SmtpClient cln = new EASendMail.SmtpClient();
                smtpgm.Port = 587;
                smtpgm.User = Console.ReadLine();
                smtpgm.Password = Console.ReadLine();
                smtpgm.Alias = "W";
                smtpgm.Protocol = ServerProtocol.SMTP;               
                smtpgm.ConnectType = SmtpConnectType.ConnectSTARTTLS;
    

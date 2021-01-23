     SmtpClient client = new SmtpClient();
            client.Credentials = new    System.Net.NetworkCredential("jorgesys@gmail.com", "patito12");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Send(mail);

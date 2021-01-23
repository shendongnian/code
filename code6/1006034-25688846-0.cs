    using (MailMessage mm = new MailMessage("sender@gmail.com", txtEmail.Text))
    {
        mm.Subject = "Account Activation";
        string body = "Hello " + txtUsername.Text.Trim() + ",";
        body += "<br /><br />Please click the following link to activate your account";
        body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("CS.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
        body += "<br /><br />Thanks";
        mm.Body = body;
        mm.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 465;
        smtp.ConnectType = SmtpConnectType.ConnectSSLAuto;
        smtp.User = "gmailid@gmail.com";
        smtp.Password = "yourpassword";
        smtp.Send(mm);
    }

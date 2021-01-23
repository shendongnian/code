     protected void BtnRegister_Click(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient("chicardari.ir", 25);
    
            smtpClient.Credentials = new System.Net.NetworkCredential("info@chicardari.ir", "Passwprd");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
    
            //Setting From , To and CC
            mail.From = new MailAddress("info@chicardari.ir", "chikardari");
            mail.To.Add(new MailAddress("vbhost.ir@gmail.com"));
            mail.CC.Add(new MailAddress("vbhost.ir@gmail.com"));
    
            smtpClient.Send(mail);
        }

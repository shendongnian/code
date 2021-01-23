    StreamReader reader = new StreamReader(Server.MapPath("~/emailer.html"));
    string readFile = reader.ReadToEnd();
    string myString = "";
    myString = readFile;
    string mailServer, mailFrom;
    int port;
    string mailId, mailPass;
    string subject;
    string mailTo;
    try
    {
        subject = "Subject";
        mailTo = "receipient@gmail.com";
        mailServer = "smtp.gmail.com";
        mailFrom = "Mail From Text";
        mailId = "sender@gmail.com";
        mailPass = "xxxxxx";
        port = 587;
        MailMessage mail = new MailMessage(mailId, mailTo, subject, myString.ToString());
        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient(mailServer, port);
        System.Net.NetworkCredential nc = new System.Net.NetworkCredential(mailId, mailPass);
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = nc;
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(mail);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Submitted successfully')", true);
    }
    catch(Exception ex){ }

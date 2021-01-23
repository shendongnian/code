    try
    {
    String userName = "ramesh";
    String passWord = "123456";
    String sendr = "ramesh@gmail.com";
    String recer = "customer@yahoo.com";
    String subject = "Comformation ";
    String body = "Dear Customer";
    MailMessage msgMail = new MailMessage(sendr, recer, subject, body);
    int PortNumber = 587; //change port number to 587
    SmtpClient smtp = new SmtpClient("smtp.gmail.com", PortNumber); //change from test to gmail
    smtp.EnableSsl = true; //set EnableSsl to true
    msgMail.IsBodyHtml = true;                                     
    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    smtp.Credentials = new System.Net.NetworkCredential(userName, passWord);
    smtp.Send(msgMail);
    MsgLP.Text = "Emailed to Customer..";
    LogInLink.Visible = true;
    }
    catch (Exception ex){
    AuditLog.LogError("ErrorE-mail " + ex.Message);
    }

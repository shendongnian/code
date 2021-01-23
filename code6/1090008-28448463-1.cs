    var fromAddress = new MailAddress("something@gmail.com", "Name");
    const string fromPassword = "pwd123";
    const string subject = "System generated test mail ";
    string email = bind_email(analyst);
    System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath("~/App_Data/test.html"));
    string body1 = sr.ReadToEnd();
    body1 = body1.Replace("#analyst#", analyst.ToString());
    body1 = body1.Replace("#task_assigned#", Session["TaskAssigned"].ToString());
    body1 = body1.Replace("#enddate#", Session["Enddate"].ToString());
    var smtp = new SmtpClient
    {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
    };
    using (var message = new MailMessage()
    {
        From = fromAddress,
        Subject = subject,
        Body = body1,
        IsBodyHtml = true
    })
    {
        message.To.Add(email);                
        smtp.Send(message);
    }
    Hope this helps

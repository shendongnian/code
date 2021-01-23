    using System.Net;
    using System.Net.Mail;	
    
    // ...
    
    MailAddress maFrom = new MailAddress("<address>", "<display_name>");
    MailAddress maTo = new MailAddress("<address>", "<display_name>");
    const string sPassword = "<password>";
    const string sSubject = "<subject>";
    const string sBody = "<body>";
    
    new SmtpClient
    {
    	Host = "smtp.gmail.com",
    	Port = 587,
    	EnableSsl = true,
    	DeliveryMethod = SmtpDeliveryMethod.Network,
    	UseDefaultCredentials = false,
    	Credentials = new NetworkCredential(maFrom.Address, sPassword)
    }.Send(new MailMessage(maFrom, maTo) { Subject = sSubject, Body = sBody });

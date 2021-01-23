    public void SendHTMLMail()
    {
    MailMessage Msg = new MailMessage();
    MailAddress fromMail = new MailAddress("administrator@aspdotnet-suresh.com");
    // Sender e-mail address.
    Msg.From = fromMail;
    // Recipient e-mail address.
    Msg.To.Add(new MailAddress("suresh@gmail.com"));
    // Subject of e-mail
    Msg.Subject = "Send Gridivew in EMail";
    Msg.Body += "Please check below data <br/><br/>";
    Msg.Body += GetGridviewData(gvUserInfo);
    Msg.IsBodyHtml = true;
    string sSmtpServer = "";
    sSmtpServer = "10.2.160.101";
    SmtpClient a = new SmtpClient();
    a.Host = sSmtpServer;
    a.EnableSsl = true;
    a.Send(Msg);
    }
    // This Method is used to render gridview control
    public string GetGridviewData(GridView gv)
    {
    StringBuilder strBuilder = new StringBuilder();
    StringWriter strWriter = new StringWriter(strBuilder);
    HtmlTextWriter htw = new HtmlTextWriter(strWriter);
    gv.RenderControl(htw);
    return strBuilder.ToString();
    }

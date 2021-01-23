    private EmailFactory emailFactory;
    public void SendAdminMail(string subject, string body, string adminAddress)
    {
        var email = emailFactory
            .From(ConfigurationManager
                      .AppSettings["Mail.NoReply.Address"]
                      .ToString(CultureInfo.InvariantCulture))
            .To(adminAddress)
            .Subject(subject)
            .Body(body)
            .UsingClient(GetOfficeClient());
        email.Message.SubjectEncoding = Encoding.UTF8;
        email.Message.BodyEncoding = Encoding.UTF8;
        email.Send();
    }

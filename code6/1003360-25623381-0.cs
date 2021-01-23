    // ensure that username, password, domain and smtpAddress are set
    var service = new ExchangeService {
        PreAuthenticate = true,
        Credentials = new WebCredentials(username, password, domain),
    };
    service.AutodiscoverUrl(smtpAddress, redirect => true);
    service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, smtpAddress);
    var inbox = Folder.Bind(service, new FolderId(WellKnownFolderName.Inbox));
    var fir = inbox.FindItems(new ItemView(10));
    foreach (var ir in fir) {
        var msg = EmailMessage.Bind(service, ir.Id, new PropertySet(EmailMessageSchema.UniqueBody));
        Console.WriteLine(msg.UniqueBody.Text);
    }

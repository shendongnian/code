    string name = string.Empty;
    using (var context = new MyEntities())
    {
        subMail result = context.subMails.FirstOrDefault(x => x.MailID == mailId);
        if (result != null)
        {
            name = result.FirstName;
        }
    }
    string output = RenderViewToString("Email","MailSubscribe", new { mailId = mailId, Name = name});

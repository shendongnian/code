    public override async Task PrivateSignal(IEventInformation ev) 
    {
        TagEvent tag = (TagEvent)ev;
        try
        {
           await smptClient.SendMailAsync(CaptureRC.SmptFromEmailAddr, ToEmails, CaptureRC.EmailSubject, "seen moving" + tag.ToString());
        }
        catch (Exception ex)
        {
            // ...
        }
    }

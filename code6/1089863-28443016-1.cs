    public async override Task PrivateSignal(IEventInformation ev) 
    {
        TagEvent tag = (TagEvent)ev;
        try
        {
            await smptClient.SendMailAsync(CaptureRC.SmptFromEmailAddr,
                ToEmails, CaptureRC.EmailSubject, "seen moving" + tag.ToString());
        }
        catch (Exception ex)
        {
            //TODO handle the error
            //TODO log the erros, along with
        }
    }

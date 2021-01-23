    public override void PrivateSignal(IEventInformation ev) 
    {
        TagEvent tag = (TagEvent)ev;
        try
        {
           smptClient.SendMail(CaptureRC.SmptFromEmailAddr, ToEmails, CaptureRC.EmailSubject, "seen moving" + tag.ToString());
        }
        catch (AggregateException ex)
        {
           //TODO handle the error
           //TODO log the erros, along with
        }
    }

    public override void PrivateSignal(IEventInformation ev) 
    {
        TagEvent tag = (TagEvent)ev;
        try
        {
           smptClient.SendMail(CaptureRC.SmptFromEmailAddr, ToEmails, CaptureRC.EmailSubject, "seen moving" + tag.ToString());
        }
        catch (Exception ex)
        {
            // ...
        }
    }

    public override void FinishedLaunching(NSObject notification)
    {
        NSAppleEventManager.SharedAppleEventManager.SetEventHandler(this, new Selector("handleGetURLEvent:withReplyEvent:"), AEEventClass.Internet, AEEventID.GetUrl);
    }
    
    [Export("handleGetURLEvent:withReplyEvent:")]
    private void HandleGetURLEvent(NSAppleEventDescriptor descriptor, NSAppleEventDescriptor replyEvent)
    {
        string keyDirectObject = "----";
        uint keyword = (((uint)keyDirectObject[0]) << 24 |
                       ((uint)keyDirectObject[1]) << 16 |
                       ((uint)keyDirectObject[2]) << 8 |
                       ((uint)keyDirectObject[3]));
        string urlString = descriptor.ParamDescriptorForKeyword(keyword).StringValue;
    }

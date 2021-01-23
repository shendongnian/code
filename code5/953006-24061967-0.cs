    static void SetOOF(ExchangeServiceBinding service)
    {
        // Identify the user mailbox for which to set OOF information.
        EmailAddress emailAddress = new EmailAddress();
    
        emailAddress.Address = "donhall@example.com";
        emailAddress.Name = String.Empty;
    
        UserOofSettings OOFSettings = new UserOofSettings();
    
        // Identify the time that a user is OOF 
        Duration duration = new Duration();
        duration.StartTime = DateTime.Now;
        duration.EndTime = DateTime.Now.AddHours(4);
        OOFSettings.Duration = duration;
    
        // Identify the external audience.
        OOFSettings.ExternalAudience = ExternalAudience.Known;
    
        // Create the reply messages.
        ReplyBody internalReply = new ReplyBody();
        ReplyBody externalReply = new ReplyBody();
        externalReply.Message = "This is my external OOF reply";
        internalReply.Message = "This is my internal OOF reply";
    
        OOFSettings.ExternalReply = externalReply;
        OOFSettings.InternalReply = internalReply;
    
        // Set OOF state.
        OOFSettings.OofState = OofState.Enabled;
    
        // Create the request.
        SetUserOofSettingsRequest request = new SetUserOofSettingsRequest();
        request.Mailbox = emailAddress;
        request.UserOofSettings = OOFSettings;
    
        try
        {
            // Send the request and return the response.
            SetUserOofSettingsResponse response = service.SetUserOofSettings(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

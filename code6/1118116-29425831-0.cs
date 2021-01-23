    private ExtendedExecutionSession session;
 
    private async void StartLocationExtensionSession()
    {
       session = new ExtendedExecutionSession();
       session.Description = "Location Tracker";
       session.Reason = ExtendedExecutionReason.LocationTracking;
       session.Revoked += ExtendedExecutionSession_Revoked;
       var result = await session.RequestExtensionAsync();
       if (result == ExtendedExecutionResult.Denied)
       {
           //TODO: handle denied
       }
    }

QBSessionManager SessionManager = null;
        try
        {
            SessionManager = new QBSessionManager();
            SessionManager.OpenConnection2("AppID", "AppName", ENConnectionType.ctLocalQBD);
            SessionManager.BeginSession("", ENOpenMode.omDontCare);
            IMsgSetRequest MsgRequest = SessionManager.CreateMsgSetRequest("US", 13, 0);
            MsgRequest.ClearRequests();
            MsgRequest.Attributes.OnError = ENRqOnError.roeStop;
            // Create request here ///////////////////////////////////////////                               
        }
        catch (Exception ex)
        {
            // Log or display the error
        }
        finally
        {
            if (SessionManager != null)
            {
                SessionManager.EndSession();
                SessionManager.CloseConnection();
                SessionManager = null;
            }
        }

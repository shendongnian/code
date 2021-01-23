    protected void Session_Start()
        {
            if (!Request.IsAuthenticated && !IsSignoutURL)
                AcceptSessionRequest(); //process local authentication
            else if (IsSignoutURL)
                RejectSessionRequest(); //kill the sessions
        }

    protected void Session_Start()
    {
         SessionDetail sdetail = new SessionDetail();
         SessionController.UserContext = sdetail;
    }

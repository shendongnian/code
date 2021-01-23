    public ActionResult Index()
    {
        if (ControllerContext.HttpContext.IsWebSocketRequest)
        {
            Trace.WriteLine("Inside IsWebSocketRequest check");
            ControllerContext.HttpContext.AcceptWebSocketRequest(DoTalking);
        }
        return new HttpStatusCodeResult(HttpStatusCode.SwitchingProtocols);
    }

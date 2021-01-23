    IOwinContext owinContext = context.GetOwinContext();
    if (owinContext.Environment.ContainsKey("Properties"))
    {
        AuthenticationProperties properties = owinContext.Environment["Properties"] as AuthenticationProperties;
        string clientId = properties.Dictionary["clientId"];
    ...
     }

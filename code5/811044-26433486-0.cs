    using(var _ctx = new PrincipalContext(ContextType.Domain, server + ":" + port))
    {
       try
       {
          var connectedServer = _ctx.ConnectedServer;
       }
       catch (Exception)
       {
          //do something with the caught exception
       }
    }

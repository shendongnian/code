    public override Task OnConnected()
        {
            var uid = Context.QueryString["uid"];
            //some stuff
        return base.OnConnected();
    }
    public override Task OnDisconnected()
    {
        var uid = Context.QueryString["uid"];
        //some stuff
        return base.OnDisconnected();
    }
    public override Task OnReconnected()
    {
        var uid = Context.QueryString["uid"];
        //some stuff
        return base.OnReconnected();
    }

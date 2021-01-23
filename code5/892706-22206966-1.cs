    public override Task OnConnected()
    {
        var myInfo = Context.QueryString["myInfo"];
        return base.OnConnected();
    }

    public override Task OnConnected()
    {
        var username= Context.QueryString['username'];
        return base.OnConnected();
    }

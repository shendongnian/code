    public override Tasks.Task OnConnected()
    {
        var referrer = Context.Request.Headers["Referer"];
        return base.OnConnected();
    }

    public override Task OnConnected()
    {
      var connectionId = Context.ConnectionId;
      var username= Context.QueryString["username"]; //here you will receive naveed as username
      return base.OnConnected();
    }

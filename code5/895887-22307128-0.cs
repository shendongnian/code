    public override Task OnConnected()
    {
        var user = new User()
        {
	        Id = Context.QueryString["Id"]
	        Name = Context.QueryString["Name"]
        }
        Groups.Add(Context.ConnectionId, user.Id);
        return base.OnConnected();
    }

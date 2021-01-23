	public override Task OnConnectedAsync()
        {
            var  username = Context.GetHttpContext().Request.Query["username"];
            // username = xxxx
            return base.OnConnectedAsync();
        }

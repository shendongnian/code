       public override Task OnConnected()
        {
            var str = Context.Request.QueryString["referrer"];
    
            if (!string.IsNullOrWhiteSpace(str))
            {
                //do stuff
            }
        }

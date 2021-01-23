    public override Task OnConnected()
        {
            try
            {
                var name = Context.User.Identity.Name;
                using (savitasEntities2 entities = new savitasEntities2())
                {
                    var user = entities.SignalRUsers
                        .Include(u => u.SignalRConnections)
                        .SingleOrDefault(u => u.UserName == name);
                    if (user == null)
                    {
                        user = new SignalRUser
                        {
                            UserName = name,
                            SignalRConnections = new List<SignalRConnection>()
                        };
                        entities.SignalRUsers.Add(user);
                    }
                    user.SignalRConnections.Add(new SignalRConnection
                    {
                        ConnectionID = Context.ConnectionId,
                        UserAgent = Context.Request.Headers["User-Agent"],
                        Connected = true
                    });
                    entities.SaveChanges();
                }
            }
   

    public override Task OnConnected()
        {
            SignalRConnectionStore.Add(Context.User.Identity.Name, Context.ConnectionId);
            
            return base.OnConnected();
        }
        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;
            //Add the connection id if it is not in it 
            if (!SignalRConnectionStore.GetConnections(name).Contains(Context.ConnectionId))
            {
                SignalRConnectionStore.Add(name, Context.ConnectionId);
            }
            return base.OnReconnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            SignalRConnectionStore.Remove(Context.User.Identity.Name, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

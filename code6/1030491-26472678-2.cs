        public override Task OnConnected()
        {
            var refererHeader = Context.Request.Headers.FirstOrDefault(h => h.Key == "Referer");
            var uriString = refererHeader.Value;
            if (!String.IsNullOrWhiteSpace(uriString))
            {
                Groups.Add(Context.ConnectionId, GetTaskToken(Context.Request));
            }
            return base.OnConnected();
        }
    Starting in SignalR 2.1.0, OnConnected is always called in response to the Ajax /start request, meaning that the Referer header should be accessible unlike with WebSocket requests.

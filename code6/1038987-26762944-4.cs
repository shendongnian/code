    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.SignalR;
    
    namespace SignalRWebRTCExample
    {
        public class WebRTCHub : Hub
        {
            //executed from javascript side via signal.server.send(name, message);
            public void Send(string from, string message)
            {
                //Code executed client side, aka, makes message available to client
                Clients.All.broadcastMessage(from, message);
            }
        }
    }

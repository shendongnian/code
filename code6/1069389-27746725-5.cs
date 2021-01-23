        static void PubSub_Client(string name)
        {
            using (var socket = ZSocket.Create(context, ZSocketType.PUB))
            {
                socket.Connect(PubSub_FrontendAddress);
                Thread.Sleep(64);
                using (var request = new ZMessage())
                {
                    request.Add(ZFrame.Create(name));
                    socket.SendMessage(request);
                }
                socket.Disconnect(PubSub_FrontendAddress);
            }
        }

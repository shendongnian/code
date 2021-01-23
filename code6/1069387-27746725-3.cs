        static void PubSub_Client(string name)
        {
            using (ZSocket socket = context.CreateSocket(ZSocketType.PUB))
            {
                using (var crypto = new RNGCryptoServiceProvider())
                {
                    var identity = new byte[8];
                    crypto.GetBytes(identity);
                    socket.Identity = identity;
                }
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

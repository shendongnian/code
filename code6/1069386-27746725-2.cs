        static void PubSub_Client(string name)
        {
            ZError error;
            using (ZSocket socket = context.CreateSocket(ZSocketType.PUB, out error))
            {
                using (var crypto = new RNGCryptoServiceProvider())
                {
                    var identity = new byte[8];
                    crypto.GetBytes(identity);
                    socket.Identity = identity;
                }
                if (!socket.Connect(PubSub_FrontendAddress, out error))
                {
                    throw new ZException(error);
                }
                Thread.Sleep(64);
                using (var request = new ZMessage())
                {
                    request.Add(ZFrame.Create(name));
                    if (!socket.SendMessage(request, out error))
                    {
                        throw new ZException(error);
                    }
                }
                if (!socket.Disconnect(PubSub_FrontendAddress, out error))
                {
                    throw new ZException(error);
                }
            }
        }

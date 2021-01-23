        internal void SendMessage(string message)
        {
                for(int i=Clients.Count - 1; i >= 0; i--)
                {
                    IGUIService callback = Clients[i];
                    if (((ICommunicationObject)callback).State == CommunicationState.Opened)
                        callback.MessageCallback(message);
                    else
                        Clients.RemoveAt(i);
                }
        }

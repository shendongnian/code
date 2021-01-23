    public interface IServer
    {
        void ClientConnected(Client client){}
        void ClientDisconnected(Client client){}
        void MessageReceived(Client client, Message message){}
        void SendMessage(Client client, Message message){}
    }
    
    public class Server<ClientTemplate> : IServer
        where ClientTemplate : Client
    {
        void IServer.ClientConnected(Client client)
        {
            ClientConnected((ClientTemplate)client);
        }
    
        void IServer.ClientDisconnected(Client client)
        {
            ClientDisconnected((ClientTemplate)client);
        }
    
        void IServer.MessageReceived(Client client, Message message)
        {
            MessageReceived((ClientTemplate)client, message);
        }
    
        void IServer.SendMessage(Client client, Message message)
        {
            SendMessage((ClientTemplate)client, message);
        }
    
        public virtual void ClientConnected(ClientTemplate client){}
        public virtual void ClientDisconnected(ClientTemplate client){}
        public virtual void MessageReceived(ClientTemplate client, Message message){}
        public virtual void SendMessage(ClientTemplate client, Message message){}
    }

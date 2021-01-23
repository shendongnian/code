    public class Clients
    {
        public List<Client> ClientList { get; set; }
        public void Execute(Action<Client> action)
        {
            ClientList.ForEach(action);
        }
    }

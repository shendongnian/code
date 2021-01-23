    [Serializable]
    public class ClientEventArgs : EventArgs
    {
        public ClientEventArgs(Client _client)
        {
            MyClient = _client;
        }
        public Client MyClient { get; set; }
    }

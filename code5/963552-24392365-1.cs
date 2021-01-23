    public class ClientCreator
    {
        private static HashSet<WebClient> clients = new HashSet<WebClient>();
        public static WebClient CreateClient()
        {
            WebClient client = new WebClient();
            lock (clients)
                clients.Add(client);
            client.Disposed += (s, args) =>
            {
                lock (clients) clients.Remove(client);
            };
            return client;
        }
    }

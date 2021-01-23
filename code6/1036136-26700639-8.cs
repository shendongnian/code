    public static class ClientDecisions
    {
        public static Decision<Client, Client> Reliable
        {
            get
            {
                return from client in Decision.Ask<Client>()
                       where !client.CriminalRecord && client.UsesCreditCard
                       select client;
            }
        }
        public static Decision<Client, Client> Wealthy
        {
            get
            {
                return from client in Decision.Ask<Client>()
                       where client.Income > 100000
                       select client;
            }
        }
        public static Decision<Client, Client> Stable
        {
            get
            {
                return from client in Decision.Ask<Client>()
                       where client.YearsInJob > 2
                       select client;
            }
        }
    }

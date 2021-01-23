    // static dictionary of clients
    public static readonly Dictionary<int, string> Clients;
    // This is the static constructor for the Client class
    static Client()
    {
        // create and populate the Clients dictionary
        Clients = new Dictionary<int, string>();
        foreach (var c in GetList())
        {
            Clients.Add(c.id, c.Nom);
        }
    }

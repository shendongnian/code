    public static class Server
    {
        public static ServerState CurrentState
        {
            return new ServerState
            {
                ...
            };
        }
    
        public static void LoadState(ServerState state)
        {
            ...
        }
    }
    ...
    IFormatter formatter = new BinaryFormatter();
    using (FileStream s = File.Create("ServerInfo.bin"))
        formatter.Serialize(s, Server.CurrentState);

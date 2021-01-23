    public class ServerList
    {
        private List<ServerInformation> servers { get; set; }
    
    	public ServerList()
    	{
    		//servers = new List<ServerInformation>;
            // constructor must include parentheses
    		servers = new List<ServerInformation>(); 
    	}
    
        public void AddServer(string name, string ipv4, string ipv6)
        {
            //servers.Add(new Server { Name = name, IPv4 = ipv4, IPv6 = ipv6 });
            // Server does not exist, but ServerInformation does
            servers.Add(new ServerInformation { Name = name, IPv4 = ipv4, IPv6 = ipv6 });  
        }
    
        //public ReadOnlyCollection<servers> GetServers()
        // The type is ServerInformation, not servers.
        public ReadOnlyCollection<ServerInformation> GetServers()
        {
            //return servers;
            // servers is not readonly
            return servers.AsReadOnly();
        }
    }

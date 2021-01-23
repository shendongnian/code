    public class Game 
    {
    	public Game()
    	{
    		this.Clients = new HashSet<Clients>(); 
    	}
    		
    	public HashSet<Client> Clients { get; set;}
    
    	public void OnClientConnect(Client newClient)
    	{
            // Are there any clients with the username that the newUser is attempting to use?
    		bool usernameIsFree = this.Clients.Any(clients => clients.UserName == newClient.UserName);
    		
    		if (usernameIsFree)
    		{
    			this.Clients.Add(newClient);
                Console.WriteLine("Username has been added to the list :)");
                // UDP stuff here...
    			return;
    		}
    		
    		Console.WriteLine("Username is already used!");
    		// UDP stuff here	
    	}
    }
    public class Client 
    {
    	public int ClientId { get; set; }
    	public IPEndPoint IPEndPoint { get; set; }
    	public string UserName { get; set; }
    }

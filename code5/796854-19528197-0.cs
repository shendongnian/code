    public class Client
    {
      public event Action<Client> Timeout;
      System.Threading.Timer timeoutTimer;
      public Client()
      {
        timeoutTimer = new Timer(timeoutHandler, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
      }
      public void timeoutHandler(object data)
      {
         CloseConnection();
         if (Timeout != null)
            Timeout();
      }
    }
    class Program
    {
       List<Client> connectedClients = new List<Client>
       void OnConnected(object clientData)
       {
          Client newClient = new Client();
          newClient.Timeout += ClientTimedOut;
          connectedClients.Add(newClient);
       }
       void ClientTimedOut(Client sender)
       {
          connectedClients.Remove(sender);
       }
    }

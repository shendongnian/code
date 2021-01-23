    public class Ident
    {
       private readonly TcpListener _listener;
       private readonly string _userId;
    
       public Ident(string userId)
       {
          _userId = userId;
          _listener = new TcpListener(IPAddress.Any, 113);
       }
    
       public void Start()
       {
          Console.WriteLine("Ident started");
          _listener.Start();
          var client = _listener.AcceptTcpClient();
          _listener.Stop();
          Console.WriteLine("Ident got a connection");
          using (var s = client.GetStream())
          {
             var reader = new StreamReader(s);
             var str = reader.ReadLine();
             var writer = new StreamWriter(s);
             Console.WriteLine("Ident got: " + str + ", sending reply");
             writer.WriteLine(str + " : USERID : UNIX : " + _userId);
             writer.Flush();
             Console.WriteLine("Ident sent reply");
          }
          Console.WriteLine("Ident server exiting");
    
       }
    }

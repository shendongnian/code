    public static void Main (string[] args)
    {
    	TcpListener server = new TcpListener (IPAddress.Any, 3001);
    	server.Start ();
    	TcpClient client = server.AcceptTcpClient ();
    	StreamReader reader = new StreamReader (client.GetStream (), Encoding.UTF8);
    	Console.WriteLine (reader.ReadLine ());
    }

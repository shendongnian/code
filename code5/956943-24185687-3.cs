    public void Main()
    {
      Boolean Ready = false;
      TcpClient client = new TcpClient(server, port);
      NetworkStream nwStream = Client.GetStream();
      StreamReader reader = new StreamReader(NwStream);
      StreamWriter writer = new StreamWriter(NwStream);
      writer.WriteLine("Hello World.");
      writer.Flush();
    
      // How do I access to Globals.Reader?
      while ((inputLine = reader.ReadLine()) != null)
      {
        Console.WriteLine(inputLine);
        ParseData(inputLine, writer);
      }
    }
    // ParseData is not well named, as it both parses data AND writes it to a stream
    // You should name them after what they actually do (e.g. ParseAndStoreTrueData)
    public static void ParseData(string data, StreamWriter writer) 
    {
      if (data.Length > 4)
      {
        if (data.Substring(0, 4) == "TRUE")
        {
          writer.WriteLine("Hello World");
          writer.Flush();
        }
      }
    }

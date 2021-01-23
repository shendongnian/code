    public Boolean _Ready;
    public TcpClient _Client;
    public NetworkStream _NwStream;
    public StreamReader _Reader;
    public StreamWriter _Writer;
    public void Main()
    {
        _Writer = new StreamWriter(_NwStream);
        _Writer.WriteLine("Hello World.");
        _Writer.Flush();
        while ((inputLine = _Reader.ReadLine()) != null)
        {
            Console.WriteLine(inputLine);
            ParseData(inputLine);
        }
    }
    public static void ParseData(string data)
    {
        if (data.Length > 4)
        {
            if (data.Substring(0, 4) == "TRUE")
            {
                _Ready = true;
                _Writer.WriteLine("Hello World");
                _Writer.Flush();
            }
        }
    }

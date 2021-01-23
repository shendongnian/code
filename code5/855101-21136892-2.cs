    static TcpClient cli = new TcpClient(); //Initialize a new TcpClient
    static void Main(string[] args)
    {
        send("Something");
        Console.ReadLine();
    }
    private static void doSomething(IAsyncResult result)
    {
        if (cli.Connected) //Connected to host, do something
        {
            Console.WriteLine("Connected"); //Write 'Connected'
        }
        else
        {
            //Not connected, do something
        }
        Console.ReadLine(); //Wait for user input
    }
    private static void send(string msg)
    {
        AsyncCallback callBack = new AsyncCallback(doSomething); //Set the callback to the doSomething void
        cli.BeginConnect("google.com", 80, callBack, cli); //Try to connect to Google on port 80
    }

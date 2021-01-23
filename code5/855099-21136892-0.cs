    private static void doSomething(IAsyncResult result)
    {
        if (result.AsyncState.ToString() == "Connected") //Connected to host, do something
        {
            Console.WriteLine(result.AsyncState.ToString()); //Write 'Connected'
        } 
        else 
        {
            //Not connected, do something 
        }
        Console.ReadLine(); //Wait for user input
    }
    private static void send(string msg)
    {
        TcpClient cli = new TcpClient(); //Initialize a new TcpClient
        AsyncCallback callBack = new AsyncCallback(doSomething); //Set the callback to the doSomething void
        cli.BeginConnect("google.com", 80, callBack, "Connected"); //Try to connect to Google on port 80 and write Connected into the AsyncState value
        //var blah = doOtherthings(msg)
        //useTheClient(blah);
    }

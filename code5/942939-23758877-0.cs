    public static Socket connect()
    {
        Socket s = null;
        try
        {
            IPEndPoint iEP = new IPEndPoint("127.0.0.1", 8080);
            s = new Socket(iEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(iEP);
            if(!s.Connected)
            {
                return null;
            }
        }
        catch(Exception e)
        {
            throw e;// Rethrow the Exception to the caller
        }
        return s;
    }
    public static void Main(String[] args)
    {
        Socket mySocket = null;
        try
        {
            mySocket = connect();
        }
        catch(SocketException e)
        {
            // TODO - Detailed error about a SocketException
            Console.Error.WriteLine("SocketException: " + e.Message + "(" + e.ErrorCode + ")");
        }
        catch(SecurityException e)
        {
            // TODO - Detailed error about a SecurityException
            Console.Error.WriteLine("SecurityException: " + e.Message);
        }
        catch(Exception e)
        {
            // TODO - Detailed error about those Exceptions :
            // ArgumentNullException, ObjectDisposedException and InvalidOperationException
            Console.Error.WriteLine(e.GetType() + ": " + e.Message);
        }
        
        if(mySocket == null)
        {
            // TODO - Error while initializing the Socket
            Console.Error.WriteLine("Error while initializing the Socket");
        }
        
        // TODO - Use your Socket here
    }

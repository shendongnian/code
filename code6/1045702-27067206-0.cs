    static WebRequest request;
    private static void sendAndReceive()
    {
        // The request with a big timeout for receiving large amout of data
        request = HttpWebRequest.Create("http://localhost:8081/index/");
        request.Timeout = 100000;
        
        // The connection timeout
        var ConnectionTimeoutTime = 100;
        Timer timer = new Timer(ConnectionTimeoutTime);
        timer.Elapsed += connectionTimeout;
        timer.Enabled = true;
    
        Console.WriteLine("Connecting...");
        try
        {
            using (var stream = request.GetRequestStream())
            {
                Console.WriteLine("Connection success !");
                timer.Enabled = false;
    
                /*
                 *  Sending data ...
                 */
                System.Threading.Thread.Sleep(1000000);
            }
    
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                /*
                 *  Receiving datas...
                 */
            }
        }
        catch (WebException e)
        {
            if(e.Status==WebExceptionStatus.RequestCanceled) 
                Console.WriteLine("Connection canceled (timeout)");
            else if(e.Status==WebExceptionStatus.ConnectFailure)
                Console.WriteLine("Can't connect to server");
            else if(e.Status==WebExceptionStatus.Timeout)
                Console.WriteLine("Timeout");
            else
                Console.WriteLine("Error");
        }
    }
    
    static void connectionTimeout(object sender, System.Timers.ElapsedEventArgs e)
    {
        Console.WriteLine("Connection failed...");
        Timer timer = (Timer)sender;
        timer.Enabled = false;
    
        request.Abort();
    }

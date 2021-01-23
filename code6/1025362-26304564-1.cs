    public static void Request(string url)
    {
      ThreadPool.QueueUserWorkItem((state) =>
      {
        try
        {
          var request = WebRequest.Create(url);
          request.Timeout = 5000;
          using(var response = request.GetResponse())
          {
              Console.Out.WriteLine("Response - " + url);
          }
        }
        catch (Exception e)
        {
          Console.Out.WriteLine(e);
        }
        Console.Out.WriteLine("Method End - " + url);
      });
    }
    
    static void Main(string[] args)
    {
      Request("http://google.com?q=a");
      Request("http://google.com?q=b");
      Request("http://google.com?q=c");
      Request("http://google.com?q=d");
      Thread.Sleep(20000);
    
      Console.In.ReadLine();
    }

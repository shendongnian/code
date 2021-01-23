       WebProxy webProxy = (WebProxy) WebRequest.DefaultWebProxy;
       if (webProxy.Address.AbsoluteUri != string.Empty)
       {
           Console.WriteLine("Proxy URL: " + webProxy.Address.AbsoluteUri);
       }

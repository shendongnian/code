    async partial  void Click_TouchUpInside (UIButton sender)
    		{
    
                ODataClientSettings settings = new ODataClientSettings();
    
                NetworkCredential proxyNC = new NetworkCredential("Username", "password");
         
                settings.OnApplyClientHandler= (System.Net.Http.HttpClientHandler clientHandler) => {
    
                    clientHandler.Proxy = new WebProxy("yourproxy.com",false,null, proxyNC);
                    clientHandler.UseProxy = true;
                };
                settings.UrlBase = "http://services.odata.org/Northwind/Northwind.svc/";
                var client= new ODataClient(settings);
    
                Console.WriteLine("before await");
    
                try {
                var packages = await client
                    .For("Customers").
                    FindEntriesAsync();
                    foreach (var package in packages)
                     {
                      //Console.WriteLine(package["CompanyName"]);
                      Console.WriteLine(package["CompanyName"]);
                     }
                    }
                    catch(AggregateException e) {
                       Console.WriteLine(e);
                       Console.WriteLine(e.InnerException);
                    }
                    Console.WriteLine("after await");
           }

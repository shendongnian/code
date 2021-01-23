           //Enter query string 
           var querystringData = new Dictionary<string, string>();
           querystringData.Add("username", "naveed");
       
           IHubProxy _hub;
           string url = @"http://localhost:8080/";
           var connection = new HubConnection(url);
           _hub = connection.CreateHubProxy("TestHub");
           connection.Start().Wait();
           connection.Start().Wait();

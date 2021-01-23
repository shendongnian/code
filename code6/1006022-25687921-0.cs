    var client = new System.Net.Http.HttpClient();
        //The next line works just fine, I get a response back
        var r = await client.GetAsync("http://www.google.com/appsstatus/rss/en");
        HttpContent responseContent = r.Content;
        //SOCKETEXCEPTION 16010 at next line
        client = new System.Net.Http.HttpClient();
        var r2 = await client.GetAsync("https://www.google.com/appsstatus/rss/en");           
        HttpContent responseContent2 = r2.Content;

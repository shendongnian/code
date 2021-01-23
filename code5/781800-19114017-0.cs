    using (var client = new HttpClient())
    {
    	var url = "http://spotlightenglish.com/feeds/appfeed/";
    	client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
    	var msg = await client.GetAsync(url);
    	if (msg.IsSuccessStatusCode)
    	{
    		var xml = await msg.Content.ReadAsStringAsync();
    		// do whatever with xml from here
    	}
    }

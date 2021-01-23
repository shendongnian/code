    public async Task<MyResultsObject> GetStuffAsync(string query, 
                                                     Action<int> totalCallback)
    {
        var Total = 0;
        var q = query;
        var keepGoing = false;
        var results = new MyResultsObject();
        do
        {
			string json;
            using(var webClient=new WebClient())
			{
				json = await webClient.DownloadStringAsync(q);
			}
            var root = JsonConvert.DeserializeObject<SomeType>(json);
            keepGoing = (root.IsMoreStuff != null);
            //process stuff
            results.SomeList.Add(root.SomeInfo);
            Total += root.Count;  //Would be nice to send Total back to caller 
            if(totalCallback!=null)
            {
               totalCallback(Total);
            }
            if (keepGoing) q = query + "&start=" + root.nextStart;
        } while (keepGoing);
        return results;
    }

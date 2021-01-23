    private string getMatchId()
    {
        using (var webClient = new System.Net.WebClient())
        {
            const string url = @"http://www.extradelar.se/match"; 
            var json = webClient.DownloadString(url);
            var matchen = JsonConvert.DeserializeObject<List<List<RootObject>>>(json);
            var matchId = matchen[0][0].match_id;
    
            return matchId;
        }
    }

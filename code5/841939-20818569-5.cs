    public int GetSummonerID(string SummonerName)
    {
        int summonerId = 0;
        WebClient client = new WebClient();
        string strJSON = client.DownloadString("http://prod.api.pvp.net/api/lol/na/v1.2/summoner/by-name/" + SummonerName + "?api_key=xxxx");
        JavaScriptSerializer js = new JavaScriptSerializer();
        if(strJSON[0] == '['){
            return js.Deserialize<KeyValue[]>(strJSON)[0].id;
        }else{
            return js.Deserialize<KeyValue>(strJSON).id;
        }
        return summonerId;
    }

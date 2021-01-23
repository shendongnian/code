    [System.Web.Services.WebMethod]
    public static string Find_Games(string user)
    {
        using (var client = new System.Net.WebClient())
        {
            return client.DownloadString(String.Concat("http://api.steampowered.com/", "IPlayerService/GetOwnedGames/v0001/?key=my_steam_key&steamid=my_steam_id&include_appinfo=1&include_played_free_games=1&format=json"));
        }
    }

    using System.Web.Helpers;    
    
    public void addBoxScore(string playerstats) 
    {
        Games gamestats = Json.Decode<Games>(playerstats);
    }

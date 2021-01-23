    [WebMethod]
    public static string GetRequestCount()
    {
        RequestProvider rP = new RequestProvider();
        int talepSayisi = rP.LastFiveDaysRequestCount();
        if (talepSayisi > 0)
        {
            return talepSayisi.ToString();
        }
        
        return "";
    }

    [Invoke]
    public List<Category> getWeather(string ICAO)
    {
        bool isexists = FtpDirectoryExists("ftp://tgftp.nws.noaa.gov/data/observations/metar/stations/" + ICAO);
        if (isexists)
        {
            List<Category> lstcat = new List<Category>();
                
            addCategoriesToList(
                lstcat,
                "http://weather.noaa.gov/pub/data/observations/metar/stations/" + ICAO,
                "METAR"
            );
            addCategoriesToList(
                lstcat,
                "http://weather.noaa.gov/pub/data/forecasts/shorttaf/stations/" + ICAO,
                "Short TAF"
            );
            addCategoriesToList(
                lstcat,
                "http://weather.noaa.gov/pub/data/forecasts/taf/stations/" + ICAO,
                "Long TAF"
            );
            return lstcat;
        }
        else
        {
            return null;
        }
    }
    private static void addCategoriesToList(List<Category> lstcat, string url, string description)
    {
        string fileString;
        //Use "using" so that `request` always gets cleaned-up:
        using (WebClient request = new WebClient()) 
        {
            try
            {
                byte[] newFileData = request.DownloadData(url);
                fileString = System.Text.Encoding.UTF8.GetString(newFileData);
            }
            catch
            {
                fileString = "N/A";
            }
        }
        lstcat.Add(new Category(description, fileString));
    }

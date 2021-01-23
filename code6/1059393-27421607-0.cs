    public static async Task<T> GetData<T>(string req, bool weather = false)
    {
        string webrequest = string.Format("{0}&{1}", req, !weather ? string.Format("key={0}", MainClass.GoogleAPI) : string.Format("APPID={0}", MainClass.WeatherID));
        var request = WebRequest.Create(webrequest) as HttpWebRequest;
        request.Method = "GET";
        request.Accept = "application/json";
        request.ContentType = "application/json";
        try
        {
           var response = await request.GetResponseAsync();
           using (var reader = new StreamReader(response.GetResponseStream()))
              return GeneralUtils.Deserialize<T>(reader.ReadToEnd());
        }
        catch (Exception ex)
        {
           Debug.WriteLine("Deserialiser failed : {0}--{1}", ex.StackTrace, ex.Message);
           throw;
        }
    }

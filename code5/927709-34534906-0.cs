    var uriBuilder = new UriBuilder(
        "https",
        "www.google.com",
        443,
        "speech-api/v2/recognize",
        "?output=json&lang=en-us&key=YOURAPIKEY");
    int sampleRate = 44100;
    
    using (var stream = File.Open("c:\\tmp\\g2.flac", FileMode.Open))
    {
    
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uriBuilder.Uri);
        request.Method = "POST";
        request.ContentType = "audio/x-flac; rate=" + sampleRate;
        request.AutomaticDecompression = DecompressionMethods.GZip;
                   
        stream.CopyTo(request.GetRequestStream());
        try
        {
            using (var resp = request.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(resp))
                {
                    Debug.WriteLine(sr.ReadToEnd());
                }
            }
        }
        catch(WebException ee)
        {
            var all = new StreamReader(ee.Response.GetResponseStream()).ReadToEnd();
            Debug.WriteLine(all);
        }
    }

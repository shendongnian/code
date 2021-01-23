            string test;
            using (WebClient strJson = new WebClient())
            {
                test = strJson.DownloadString("https://api.twitch.tv/kraken/streams/ogaminglol");
            }
            var streams1 = JsonConvert.DeserializeObject<Streams>(test);
            var streams2 = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Streams>(test);
    In both cases you will see the dictionary contents are present.

      List<RootObject> rootobject = new List<RootObject>();
        using (var webclient = new WebClient())
        {
            var Ids = webclient.DownloadString(" https://api.guildwars2.com/v2/commerce/listings");
            foreach (var id in Ids.Substring(1, s.Length-2).Split(','))
            {
                string url = string.Format("{0}/{1}","https://api.guildwars2.com/v2/commerce/listings",id);
                var res = webclient.DownloadString(url);
                var jsonObject = JsonConvert.DeserializeObject<RootObject>(res);
                rootobject.Add(jsonObject);
            }
            
           
        }

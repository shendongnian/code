    using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("http://backpack.tf/api/IGetPrices/v3/?format=json&key=52f75dab4dd7b82f698b4568");
                Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(json);
                var value = (int)o["response"]["prices"]["5021"]["6"]["0"]["current"]["value"];
                Console.WriteLine(value);
            }

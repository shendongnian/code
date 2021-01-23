    namespace SO27839862
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent", "Nobody");
    
                    String response = client.DownloadString(new Uri("https://api.worldoftanks.ru/wot/encyclopedia/tanks/?application_id=demo"));
                    Response asd = JsonConvert.DeserializeObject<Response>(response);
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
    
        public class Response
        {
            public string status { get; set; }
            public int count { get; set; }
            public Dictionary<String, Tank> data { get; set; }
        }
    
        public class Tank
        {
            public string nation_i18n { get; set; }
            public string name { get; set; }
            public int level { get; set; }
            public string image { get; set; }
            public string image_small { get; set; }
            public string nation { get; set; }
            public bool is_premium { get; set; }
            public string type_i18n { get; set; }
            public string contour_image { get; set; }
            public string short_name_i18n { get; set; }
            public string name_i18n { get; set; }
            public string type { get; set; }
            public int tank_id { get; set; }
        }
    }

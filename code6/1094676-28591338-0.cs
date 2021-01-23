    public class RootObject
        {
            public RootObject(JObject obj)
            {
                Title = obj["Title"].ToString();
                var year = obj["year"].ToString();
                Year = year == "N/A" ? 0 : int.Parse(year);
                var metascore = obj["Metascore"].ToString();
                Metascore = metascore == "N/A" ? 0 : int.Parse(metascore);
            }
            public string Title { get; set; }
            public int Year { get; set; } 
            public double Metascore { get; set; } 
        }
        static void Main(string[] args)
        {
            string json = "{\"Title\":\"test\",\"year\":\"2012\",\"Metascore\":\"N/A\"}";
            RootObject root = new RootObject(JObject.Parse(json));
        }

    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                string url = "http://itunes.apple.com/WebObjects/MZStoreServices.woa/ws/genres?id=26";
                string json = client.DownloadString(url);
                var genres = JsonConvert.DeserializeObject<Dictionary<string, PodcastGenreInfo>>(json);
                Dump(new PodcastGenreInfo { GenreName = "Genres", Subgenres = genres }, "");
            }
        }
        private static void Dump(PodcastGenreInfo genre, string indent)
        {
            Console.WriteLine(indent + genre.GenreName);
            if (genre.Subgenres != null)
                foreach (var kvp in genre.Subgenres)
                    Dump(kvp.Value, indent + "  ");
        }
        public class PodcastGenreInfo
        {
            [JsonProperty("name")]
            public string GenreName { get; set; }
            [JsonProperty("subgenres")]
            public Dictionary<string, PodcastGenreInfo> Subgenres { get; set; }
        }
    }

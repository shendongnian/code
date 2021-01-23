    public class FilmInfo
    {
        [JsonProperty("cesta")]
        public string Path { get; set; }
        [JsonProperty("rok")]
        public int Year { get; set; }
        // other properties
        public string jmeno { get; set; }
        public string serie { get; set; }
        public string hodnoceni { get; set; }
        public int dil { get; set; }
        public string obrazek { get; set; }
    };
    static void Main(string[] args)
    {
        var json = @"
        [
            {
                'cesta': 'C:\\Users\\Kenny\\Videos\\[Glitch Hop or 110BPM]   Rogue   Night After Night [Monstercat Release].wmv',
                'jmeno': 'Test',
                'serie': '0',
                'hodnoceni': '',
                'herci': '',
                'rok': 0,
                'dil': 0,
                'obrazek': 'file:///C:/Users/Kenny/Pictures/Pozadi­/1.jpg'
            },
            {
                'cesta': 'C:\\Users\\Kenny\\Videos\\[EDM]   Laszlo x WRLD   You  Me [Monstercat Release].mp4',
                'jmeno': 'Test2',
                'serie': '0',
                'hodnoceni': '',
                'herci': '',
                'rok': 0,
                'dil': 0,
                'obrazek': 'file:///C:/Users/Kenny/Pictures/Pozadi/1.jpg'
            }
        ]";
        var list = JsonConvert.DeserializeObject<List<FilmInfo>>(json);
    }

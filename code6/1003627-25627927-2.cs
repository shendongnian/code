    public class sample_model
    {
        public sample_model(string artist, string song, string extra = "")
        {
            this.Artist = artist;
            this.Song = song;
            this.Extra = extra;
        }
        public string Artist { get; set; }
        public string Song { get; set; }
        public string Extra { get; set; }         // this is your tag
    }

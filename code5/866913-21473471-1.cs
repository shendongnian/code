    public class Size
    {
        public Size(int w, int h)
        {
            this.Width = w;
            this.Height = h;
        }
        [JsonProperty("width")]
        public int Width
        {
            get;
            set;
        }
        [JsonProperty("height")]
        public int Height
        {
            get;
            set;
        }
    }

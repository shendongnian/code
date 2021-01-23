    public class Animation
    {
        [JsonProperty]
        private readonly string name;
        
        [JsonConverter(typeof(RectangleListConverter))]
        [JsonProperty]
        private readonly IList<Rectangle> frames;
    }

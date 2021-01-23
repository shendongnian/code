    public class Environment
    {
       
        public string Name { get; set; }
        public Shelter Shelter { get; set; }
        public Shelter[] Shelters { get; set; }
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Shelter
    {
        Indoor,
        Outdoor
    }

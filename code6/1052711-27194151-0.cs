    public class Tile
    {
        public string TileData { get; set; }
    }
    public class Option
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    [XmlRoot("GameSave")]
    public class GameSave
    {
        [XmlArray("Map")]
        [XmlArrayItem("Tile")]
        public List<Tile> Tiles { get; set; }
        [XmlArray("Options")]
        [XmlArrayItem("Option")]
        public List<Option> Options { get; set; }
    }

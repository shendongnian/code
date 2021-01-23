    [Serializable]
    public class Coordinate
    {
        public string x { get; set; }
        public string y { get; set; }
        public Coordinate() {}
    }
    public class CoordinateList
    {
        public List<Coordinate> Coordinate { get; set; }
    }

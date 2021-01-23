    internal class Coordinate
    {
        public int coordID { get; set; }
        public string Coordinates { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Coordinate> coordinates {get;set;}
    }

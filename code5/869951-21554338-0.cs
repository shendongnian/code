    public class Coordinate
    {
        public int X1 {get; set;}
        public int Y1 {get; set;}
        public int Z1 {get; set;}
        public int X2 {get; set;}
        public int Y2 {get; set;}
        public int Z2 {get; set;}
        public Coordinate(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            X1 = x1; Y1 = y1; Z1 = z1; X2 = x2; Y2 = y2; Z2 = z2;
        }
    }
    [XmlArray("Robot")]
    public Coordinate[] points = new Coordinate[] {
        new Coordinate(1, 2, 3, 4, 5, 6),
        new Coordinate(6, 5, 4, 3, 2, 1),
        new Coordinate(2, 3, 4 ,5, 6, 7),
    }
    // serialize (remove long namespace)
    var space = new XmlSerializerNamespaces();
    space.Add("", "");
    var serializer = new XmlSerializer(points.GetType()); // typeof(Coordinate[])
    using (var stream = new FileStream("robot.xml", FileMode.Create))
        serializer.Serialize(stream, points, space);
    // deserialize
    using (var stream = new FileStream("robot.xml", FileMode.Open, FileAccess.Read))
        points = (Coordinate[])serializer.Deserialize(stream);

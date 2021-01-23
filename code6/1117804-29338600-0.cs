    class Program
    {
        public enum Direction { North, East, South, West };
        static List<Location> myObjects = new List<Location>();
        public class Location
        {
            public Int16 X { get; set; }
            public Int16 Y { get; set; }
            public Direction  Z { get; set; }
            public Location(Int16 x, Int16 y, Direction z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }
        static void Main(string[] args)
        {
            myObjects.Add(new Location(10, 10, Direction.North));
            myObjects.Add(new Location(30, 20, Direction.East));
            myObjects.Add(new Location(50, 5, Direction.West));
            myObjects.Add(new Location(60, 32, Direction.South));
            foreach (Location it in myObjects)
            {
                Console.WriteLine("Parked Location is {0}, X is {1}, Y is {2}", it.Z, it.X, it.Y);
            }
        }
    }

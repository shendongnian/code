    class Program
    {
        static void Main(string[] args)
        {
            List<LocationUpdate> locationUpdates =
                new List<LocationUpdate>
                {
                    new LocationUpdate {UserID = 1, Position = 2},
                    new LocationUpdate {UserID = 1, Position = 3},
                    new LocationUpdate {UserID = 2, Position = 1},
                    new LocationUpdate {UserID = 2, Position = 2},
                    new LocationUpdate {UserID = 1, Position = 4},
                    new LocationUpdate {UserID = 3, Position = 1}
                };
            IEnumerable<Tuple<int, List<MyClass>>> result = locationUpdates.GroupBy(x => x.UserID)
                .Select(x => new Tuple<int, List<MyClass>>(x.Key,
                    x.Select(y => new MyClass {Position = y.Position, UserID = y.UserID}).ToList()));
            foreach (Tuple<int, List<MyClass>> tuple in result)
            {
                Console.WriteLine("User {0}", tuple.Item1);
                foreach (MyClass myClass in tuple.Item2)
                    Console.WriteLine("User {0}, Position {1}", myClass.UserID, myClass.Position);
            }
            Console.ReadLine();
        }
        public class MyClass
        {
            public int Position { get; set; }
            public int UserID { get; set; }
        }
        public class LocationUpdate
        {
            public int Position { get; set; }
            public int UserID { get; set; }
        }
    }

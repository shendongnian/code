    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication4
    {
        class Program
        {
            public enum Direction
            {
                North,
                West,
                South,
                East
            };
            public class Location
            {
                public Int16 X { set; get; }
                public Int16 Y { set; get; }
                public Direction Z { set; get; }
            }
            static void Main()
            {
                List<Location> allLocations = new List<Location> {
                    new Location() {X=1, Y=2, Z = Direction.North },
                    new Location() {X=2, Y=3, Z = Direction.West },
                    new Location() {X=3, Y=4, Z = Direction.East }
                };
                var allX = from loc in allLocations select loc.X;
                foreach (int i in allX)
                {
                    Console.WriteLine(i);
                }
                var asAnArray = allX.ToArray();
                Console.WriteLine("Array is:" + (asAnArray == null ? "Null" : asAnArray.Length.ToString()));
                Console.ReadLine();
                // Or using a different syntax for the same effect.
                asAnArray = allLocations
                    .Select(loc => loc.X)
                    .ToArray();
                Console.WriteLine("Array is:" + (asAnArray == null ? "Null" : asAnArray.Length.ToString()));
                Console.ReadLine();
            }
        }
    }

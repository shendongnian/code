    using System;
    using System.Linq;
    
    namespace DistinctValues
    {
        public struct Location
        {
            public Location(double longitude, double latitude) : this()
            {
                this.Longitude = longitude;
                this.Latitude = latitude;
            }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
    
            public override string ToString()
            {
                return string.Format("Longitude: {0}, Latitude={1}", this.Longitude, this.Latitude);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var a = new Location[] 
                { 
                    new Location(123.456, 456.789),
                    new Location(123.456, 456.789),
                    new Location(234.567, 890.123),
                };
                var b = new Location[]
                {
                    new Location(123.456, 456.789),
                    new Location(890.123, 456.789),
                };
    
                // Join array a and b. Uses union to pick distinct items from joined arrays
                var result = a.Union(b);
    
                // Dump result to console
                foreach(var item in result)
                    Console.WriteLine(item);
            }
        }
    }

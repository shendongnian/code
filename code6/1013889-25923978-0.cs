    using System;
    using System.Collections.Generic;
    using ConsoleApplication3;
    
    public class Program
    {
        internal class Car : IVehicle
        {
            public List<string> Features { get; set; }
            public string ModelNumber { get; set; }
            public string ModelCode { get; set; }
        }
    
        internal class Bike : IVehicle
        {
            public string ModelNumber { get; set; }
            public List<string> Features { get; set; }
            public string ModelCode { get; set; }
        }
    
        public static void Main()
        {
            var carCatelogue = new Dictionary<Car, int>(new GlobalEqualityComparer());
            var bikeCatelogue = new Dictionary<Bike, int>(new GlobalEqualityComparer());
    
            carCatelogue.Add(new Car()
            {
                ModelCode = "100",
                ModelNumber = "CAR-01",
                Features = new List<string> { "BEST ENGINE", "5 GEAR", "SPOTY" }
            }, 5);
    
            carCatelogue.Add(new Car()
            {
                ModelCode = "100",
                ModelNumber = "CAR-02",
                Features = new List<string> { "SUPER FAST ENGINE", "4 GEAR", "SPOTY RED" }
            }, 10);
    
            // This Statement will throw exception because car-02 key already exists.
            carCatelogue.Add(new Car()
            {
                ModelCode = "100",
                ModelNumber = "CAR-02",
                Features = new List<string> { "SUPER FAST ENGINE", "4 GEAR", "SPOTY RED" }
            }, 10);
    
            bikeCatelogue.Add(new Bike()
            {
                ModelCode = "200",
                ModelNumber = "BIK-01",
                Features = new List<string> { "800 CC", "10 GEAR", "SPOTY BLACK" }
            }, 5);
    
    
            // this will throw exception because the key is aleady exists.
            bikeCatelogue.Add(new Bike()
            {
                ModelCode = "200",
                ModelNumber = "BIK-01",
                Features = new List<string> { "800 CC", "10 GEAR", "SPOTY BLACK" }
            }, 5);
        }
    
        private class GlobalEqualityComparer : IEqualityComparer<IVehicle>
        {
            public bool Equals(IVehicle x, IVehicle y)
            {
                return x.ModelNumber.Equals(y.ModelNumber, StringComparison.CurrentCultureIgnoreCase)
                && x.ModelCode.Equals(y.ModelCode, StringComparison.CurrentCultureIgnoreCase);
            }
    
            public int GetHashCode(IVehicle obj)
            {
                return string.Format("{0}{1}", obj.ModelCode, obj.ModelNumber).GetHashCode();
            }
        }
    }

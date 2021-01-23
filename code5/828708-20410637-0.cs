        static void Main(string[] args)
        {
            var vehicles = new List<Vehicle>();
            vehicles.Add(new Car() { NoOfSeats = 2 });
            vehicles.Add(new Car() { NoOfSeats = 4 });
            vehicles.Add(new Van() { Weight = 2000 });
            vehicles.Add(new Van() { Weight = 3000 });
            foreach (var vehicle in vehicles)
            {
                if (vehicle is Car)
                {
                    Console.WriteLine("I'm a car");
                }
                if (vehicle is Van)
                {
                    Console.WriteLine("I'm a van");
                }
            }
            Console.ReadKey();
        }
        class Vehicle
        {
        }
        class Car : Vehicle
        {
            public int NoOfSeats { get; set; }
        }
        class Van : Vehicle
        {
            public int Weight { get; set; }
        }
    }

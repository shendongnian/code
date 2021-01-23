     namespace Cars
    {
        class Program
        {
            static void Main(string[] args)
            {
                                    List<Car> myCars = new List<Car>() {
                    new Car() { Make="BMW", Model="550i", Color=CarColor.Blue, StickerPrice=55000,     Year=2009 },
                new Car() { Make="Toyota", Model="4Runner", Color=CarColor.White, StickerPrice=35000, Year=2010 },
                new Car() { Make="BMW", Model="745li", Color=CarColor.Black, StickerPrice=75000, Year=2008 },
                new Car() { Make="Ford", Model="Escape", Color=CarColor.White, StickerPrice=28000, Year=2008 },
                new Car() { Make="BMW", Model="550i", Color=CarColor.Black, StickerPrice=57000, Year=2010 }
                };
                while (true)
                {
                    Console.WriteLine("Type \"all\" to see total value of all cars");
                    Console.WriteLine("Type \"bmw\" to see total value of all bmws");
                    Console.WriteLine("Type \"toyota\" to see total value of all Toyotas");
                    Console.WriteLine("Type \"ford\" to see total value of all Fords");
                    string userValue = Console.ReadLine();
                    Console.WriteLine();
                    if (userValue == "all")
                    {
                        var _orderedCars = myCars.OrderByDescending(p => p.Year);
                        foreach (var car in _orderedCars)
                        {
                            Console.WriteLine("{0} {1} - {2} - {3:C}", car.Make, car.Model, car.Year, car.StickerPrice);
                        }
                        var sum = _orderedCars.Sum(p => p.StickerPrice);
                        Console.WriteLine("{0:C}", sum);
                    }
                    else if (userValue == "bmw")
                    {
                        var _bmws = myCars.Where(car => car.Make == "BMW");
                        foreach (var car in _bmws)
                        {
                            Console.WriteLine("{0} {1} - {2}- {3:C}", car.Make, car.Model, car.Year, car.StickerPrice);
                        }
                        var sum = _bmws.Sum(p => p.StickerPrice);
                        Console.WriteLine("{0:C}", sum);
                    }
                    else if (userValue == "toyota")
                    {
                        var _toyotaCars = myCars.Where(car => car.Make == "Toyota");
                        foreach (var car in _toyotaCars)
                        {
                            Console.WriteLine("{0} {1} - {2} - {3:C}", car.Make, car.Model, car.Year, car.StickerPrice);
                        }
                        var sum = _toyotaCars.Sum(p => p.StickerPrice);
                        Console.WriteLine("{0:C}", sum);
                    }
                    else if (userValue == "ford")
                    {
                        var _fordCars = myCars.Where(car => car.Make == "Ford");
                        foreach (var car in _fordCars)
                        {
                            Console.WriteLine("{0} {1} - {2} - {3:C}", car.Make, car.Model, car.Year, car.StickerPrice);
                        }
                        var sum = _fordCars.Sum(p => p.StickerPrice);
                        Console.WriteLine("{0:C}", sum);
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Exit program (Y/N)?");
                        var answer = Console.ReadLine();
                        if (answer.ToString().ToUpper() != "N")
                        {
                            break;
                        }
                    }
                    Console.WriteLine();
                }
            }
            class Car
            {
                public string Make { get; set; }
                public string Model { get; set; }
                public int Year { get; set; }
                public double StickerPrice { get; set; }
                public CarColor Color { get; set; }
            }
            enum CarColor
            {
                White,
                Black,
                Red,
                Blue,
                Yellow
            }
        }
    }

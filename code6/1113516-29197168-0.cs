    static void AddCar<T>(List<T> avaliable_cars) 
    	   where T : Car ,new()
        {
            int x = 0;
    
            Console.WriteLine("Adding new car:");
            Console.WriteLine("1 - Car");
            Console.WriteLine("2 - Sport Car");
            Console.WriteLine("3 - Truck");
    
            x = int.Parse(Console.ReadLine());
    
            switch (x)
            {
                case 1: 
                {
                    Console.WriteLine("Adding new Car.");
    
                    avaliable_cars.Add(new T());
                    Console.WriteLine("Brand");
                    string brand_tmp = Console.ReadLine();
                    Console.WriteLine("Model");
                    string model_tmp = Console.ReadLine();
                    avaliable_cars.Add(new T()
                    {
                        brand = brand_tmp,
                        model = model_tmp
                    });
    
                } break;
            }
    
       }

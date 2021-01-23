        Console.WriteLine("Please enter key 1-5");
        int key =Convert.Int32(Console.ReadLine());
        
        while (true)
        {
            switch (key)
            {
                case 1: Console.WriteLine("ur option "+key);
                    break;
                case 2: Console.WriteLine("ur option " + key);
                    break;
                case 3: Console.WriteLine("ur option " + key);
                    break;
                case 4: Console.WriteLine("ur option " + key);
                    break;
                case 5: Console.WriteLine("ur option " + key);
                    break;
                default:
                    Console.WriteLine("invalid choice ,quitting the loop");
                    return;
                    
            }
            Console.WriteLine("Please enter key 1-5");
             key = Console.ReadLine();
        }
        Console.WriteLine("outside loop");
            

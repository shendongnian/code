            int val;
            var success = int.TryParse(Console.ReadLine(), out val);
            if (success)
            {
                switch (val)
                {
                    case 1:
                        Console.WriteLine("has been added to Guest1");
                        break;
                    case 2:
                        Console.WriteLine("has been added to Guest2");
                        break;
                    case 3:
                        Console.WriteLine("has been added to Guest3");
                        break;
                    default:
                        Console.WriteLine("Default has been used");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid value");
            }

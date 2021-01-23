    int input = ...
    switch (input)
    {
        case 0:
            Console.WriteLine("Zero");
            default;
        default:
            switch (input < 100)
            {
                case true:
                    switch (Math.Abs(input) % 10)
                    {
                        case 0:
                            Console.WriteLine("Multiple of 10");
                            break;
                        case 2:
                        case 4:
                        case 6:
                        case 8:
                            Console.WriteLine("Even");
                            break;
                        default:
                            Console.WriteLine("Odd");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Too large");
                    break;
            }
            break;
    }

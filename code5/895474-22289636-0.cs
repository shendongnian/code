    int a = 0;
    int b = 0;
    int c = 0;
    while (c < 2)
    {
        Console.WriteLine("Give me a number");
        int h;
        if(!Int32.TryParse(Console.ReadLine(), out h)
        {
            Console.WriteLine("Not a valid number");
            continue;
        }
        switch (c)
        {
            case 0:
                a = h;
                if(a <100 || a>250)
                    Console.WriteLine("That number is too large");
                else 
                   c = 1;
                break;
    
            case 1:
                b = h;
                if(a < 100 || a > 250)
                     Console.WriteLine("That number is too large");
                else
                   c = 2;
                break;
        }
    }
    
    Console.WriteLine("{0}",a+b);
    Console.ReadKey();
     

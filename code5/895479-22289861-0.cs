    int GetNumberBetween( int minValue, int maxValue )
    {
        int h;
        for (;;)
        {
            Console.WriteLine("Give me a number");
            h = Convert.ToInt32(Console.ReadLine());
            if ( h >= minValue && h <= maxValue )
                break;
            Console.WriteLine("I don't like that number, try again");
        }
        return( h );
    }
    void DisplaySum( void )
    {
        int a = GetNumberBetween( 100, 250 );
        int b = GetNumberBetween( 100, 250 );
        Console.WriteLine("{0}",a+b);
        Console.ReadKey();
    }

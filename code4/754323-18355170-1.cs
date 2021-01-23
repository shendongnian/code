    Int32 a = 3;
    Int32 b = 5;
    
    if (int.TryParse(Console.ReadLine(), out a))
    {
        if (int.TryParse(Console.ReadLine(), out b))
        {
            Int32 a_plus_b = a + b;
            Console.WriteLine("a + b =" + a_plus_b.ToString());
        }
        else
        {
             //error parsing second input
        }
    }
    else 
    {
         //error parsing first input
    }       

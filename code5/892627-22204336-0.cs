    if(double.TryParse(Console.ReadLine(), out i))
    {
         double j = (0.17 * i);
         System.Console.WriteLine("Your weight on the moon will be" + j);
    }
    else 
    {
        Console.WriteLine("You entered an invalid value!");
    }

    public static void Main() 
    {
        ConsoleKeyInfo cki;
      
        Console.WriteLine("Press the Escape (Esc) key to quit: \n");
        do 
        {
            cki = Console.ReadKey();
            // do something with each key press until escape key is pressed
        } while (cki.Key != ConsoleKey.Escape);
    }

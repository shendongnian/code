    static void Main(string[] args)
        {
            while (true)
            {
                readkey();
            }
        }
        public static void readkey()
        {
            ConsoleKeyInfo input = Console.ReadKey();
    switch(input.Key)
    {
        case ConsoleKey.D9:
             Console.Clear();
             Console.WriteLine("U heeft het programma succesvol afgesloten!");
             //You might want to wait:  System.Threading.Thread.Sleep(5000);
             Environment.Exit(0);
        break;
        case ConsoleKey.D1:
             overzichtmp();
        break;
        case ConsoleKey.D2:
             overzichtvr();
        break;
        default:
        {
            Console.Clear();
            Console.WriteLine("Voer een geldig nummer in!");
            // possibly add the wait here as well
            showmenu();
            break;
        }
    
        }

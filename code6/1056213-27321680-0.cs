    static void Main(string[] args)
    {
        Level1();
    }
    static void Level1()
    {
        Console.WriteLine("Welcome to AlexAdventureLand.\nPlease press the enter key to start.");
        Console.ReadKey();
        Console.WriteLine("You are a rabbit in a burrow. There is a badger outside. \nPress 1 to leave the burrow. \nPress 2 to wait.");
        int selection = int.Parse(Console.ReadLine());
        if (selection == 1)
        {
            Console.WriteLine("The badger sees you and eats you. \nYou fail. \n\nPress enter to try again.");
            Console.ReadKey();
            Level1();
        }
        else if (selection == 2)
        {
            Console.WriteLine("The badger scurries away!");
            Level2();
        }
        else
        {
            Console.WriteLine("You pressed the wrong button. Start again.");
            Level1();
        }
    }
    static void Level2()
    {
        Console.WriteLine("Now what do you want to do? \nPress 1 to leave burrow. \nPress 2 to wait.");
        int selection = int.Parse(Console.ReadLine());
        if (selection == 1)
        {
            Console.WriteLine("You leave the burrow and look around.");
            Console.ReadKey();
            Level3A();
        }
        else if (selection == 2)
        {
            Console.WriteLine("You wait a little longer. \nYou can hear footsteps around your burrow. You wonder whether it's your friend - troy - or the badger still.");
            Level3B();
        }
        else
        {
            Console.WriteLine("You pressed the wrong button. Start again.");
            Level2();
        }
    }
    static void Level3A()
    {
        Console.WriteLine("PlaceHolder");
        Console.ReadKey();
    }
    static void Level3B()
    {
        Console.WriteLine("PlaceHolder");
        Console.ReadKey();
    }

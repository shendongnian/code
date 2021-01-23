    static void Main(string[] args)
    {
        Player player = new Player(100);
        Console.WriteLine(player.Health);
        ChangeHealth(player);
        Console.WriteLine(player.Health);
        ChangeHealthByRef(ref player);
        Console.WriteLine(player.Health);
        ChangePlayer(player);
        Console.WriteLine(player.Health);
        ChangePlayerByRef(ref player);
        Console.WriteLine(player.Health);
    }
    static void ChangeHealth(Player player)
    {
        player.Health = 80;
    }
    static void ChangeHealthByRef(ref Player player)
    {
        player.Health = 60;
    }
    static void ChangePlayer(Player player)
    {
        player = new Player(40);
    }
    static void ChangePlayerByRef(ref Player player)
    {
        player = new Player(20);
    }

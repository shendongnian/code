    public class Trap
    {
        public int X = 0;
        public int Y = 0;
    }
    Console.WriteLine("Please enter the number of traps.");
    Random rnd = new Random();
    int amount;
    List<Trap> traps = new List<Trap>();
    amount = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Coordinates for {0} traps", amount);
    for(int i = 0; i < amount; i++)
    {
        Trap temp = new Trap();
        temp.X = rnd.Next(1, 11);
        temp.Y = rnd.Next(1, 11);
        Console.WriteLine("Coordinates for Trap {0} - {1},{2}", i + 1, temp.X, temp.Y);
        traps.Add(temp);
    }

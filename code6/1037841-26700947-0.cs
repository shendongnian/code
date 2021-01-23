    class Program
    {
        static void Main(string[] args)
        {
            int[] Dice = new int[5] { 1, 6, 3, 1, 3 };
            Array.Sort(Dice);
            Array.Reverse(Dice);
            Console.WriteLine("The largest pair is ({0}, {1})", Dice[0], Dice[1]);
        }
    }

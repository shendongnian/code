    class Program
    {
        static void Main(string[] args)
        {
            int[] Dice = new int[5] { 1, 6, 3, 1, 3 };
            Array.Sort(Dice);
            Array.Reverse(Dice);
            for (int i = 1; i < Dice.Length; i++)
            {
                if (Dice[i] == Dice[i - 1])
                {
                    Console.WriteLine("The largest pair is ({0}, {1})", Dice[i], Dice[i-1]);
                    break;
                }
            }
        }
    }

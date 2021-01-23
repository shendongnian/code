    class Program
    {
        [Flags]
        enum Options
        {
            None = 0,
            Chicken = 1,
            Cow = 2,
            Egg = 4,
        }
        enum Possibilities
        {
            Order1 = (Options.Chicken << 4) + (Options.Cow << 2) + Options.Egg,
            Order2 = (Options.Cow << 4) + (Options.Chicken << 2) + Options.Egg,
            Order3 = (Options.Egg << 4) + (Options.Cow << 2) + Options.Chicken,
        }
        static void Main(string[] args)
        {
            //this should result in scenario 1
            //string[] myOrderofHistory = { "Chicken", "Cow", "Egg" };
            //this should result in scenario 2
            string[] myOrderofHistory = { "Cow", "Chicken", "Egg" };
            int[] shiftValue = new int[] { 4, 2, 0 };
            int shiftIndex = 0;
            int possibility = 0;
            foreach (string history in myOrderofHistory)
            {
                Options options = (Options)Enum.Parse(typeof(Options), history);
                possibility += ((int)options) << shiftValue[shiftIndex];
                shiftIndex++;
            }
            Console.WriteLine(((Possibilities)possibility).ToString());
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }

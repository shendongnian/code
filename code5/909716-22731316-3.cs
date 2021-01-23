    class Program
    {
        static int tmp;
        static void Main(string[] args)
        {
            List<int> alreadyFired = new List<int>();                   
            while (alreadyFired.Count != 6)
            {
                Random rng = new Random();
                int diceresult = rng.Next(1,7);
                foreach (var item in alreadyFired)
                {
                    if (item == diceresult)
                    {
                        tmp = item;
                    }
                }
     
                if (!(tmp == diceresult))
                {
                    alreadyFired.Add(diceresult);                 
                    Console.WriteLine(diceresult);
                }
            }
            Console.WriteLine("no events left");
            Console.ReadKey();
        }
    }

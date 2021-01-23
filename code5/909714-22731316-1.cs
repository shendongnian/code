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
    
                    for (int i = 0; i < alreadyFired.Count; i++)
                    {
                        tmp = alreadyFired[i];
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

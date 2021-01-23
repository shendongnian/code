     static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                Random randNum = new Random();
                int[] rArray= Enumerable
                    .Repeat(0, n)
                    .Select(i => randNum.Next(1, 10)) // whatever your range is
                    .ToArray();
    
                foreach (var a in rArray){
                    Console.WriteLine(" " + a);
                    
                }
                Console.ReadLine();
            }

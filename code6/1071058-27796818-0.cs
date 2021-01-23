            Console.WriteLine("how many random numbers you want?");
             int num = 0;
            int.TryParse(Console.ReadLine(), out num);
            Random rand = new Random();
            int[] numList = new int [num];
            for (int i = 0; i < num; i++)
            {
                numList[i] = rand.Next(0, 10);
            } 
            Console.WriteLine("\nRandom number : ");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(numList[i].ToString());
            }
            Console.ReadLine();

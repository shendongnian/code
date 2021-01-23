    using System;
    
    class Program
    {
    
        public static String GetTimestamp()
        {
            DateTime saveNow = DateTime.Now;
            return saveNow.ToString("yyyyMMddHHmmssffff");
        }
    
        public static int ThrowDice()
        {
            int randVal1, randVal2;
            string TS1, TS2;
    
            
            randVal1 = rand.Next(1,7);
            TS1 = GetTimestamp();
            randVal2 = rand.Next(1,7);
            TS2 = GetTimestamp();
    
            Console.WriteLine("Dice 1: \t" + randVal1 + ' ' + TS1);
            Console.WriteLine("Dice 2: \t" + randVal2 + ' ' + TS2);
            Console.WriteLine("-----------------");
    
            return randVal1 + randVal2;
        }
    	static Random rand ;
    	
        static void Main()
        {
    		rand = new Random();
    		
            for(int i = 1; i<=10;i++)
            {
                Console.WriteLine("Dice Roll #" + i);
                Console.WriteLine("Dice Sum:\t" + ThrowDice());
                Console.WriteLine();
            }
        }
    }

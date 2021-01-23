    using System;
    namespace Dice
    {
        class Dice
        {
            private Random randy;
            int total;
            int [] rolls = new int[7];
            public static void Main()
            {
                Dice myDice = new Dice();
                myDice.randy = new Random();
                Console.Clear();
                myDice.manyThrow();
                myDice.throwDice();
                myDice.countEm();
                Console.ReadKey();
            }
            //*******************************************************
            public void throwDice()
            {
                double count = 0;
                while (count != total)
                {
                    count++;
                    Console.WriteLine("Throw No " + count + " is " + oneThrow());
                }
            }
            //*******************************************************
            public int oneThrow()
            {
                var result = randy.Next(6) + 1;        // pick a number from 1 to 6 and return this
                this.rolls[result]++;
                return result;
            }
            public int manyThrow()
            {
                Console.Write("How many times do you want to roll\t");
                total = Convert.ToInt32(Console.ReadLine());
                return total;
            }
            public void countEm()
            {
                for (int i = 1; i<7; i++)
                {
                    Console.WriteLine("{0} rolled {1} times", i, rolls[i]);
                }
            }
        }
    }

    using System;
    
    namespace Week_6_Project_2
    {
        class Program
        {
            // ******************************************
            // THIS IS A SINGLE INSTANCE OF Random.
            // It's seeded to increase the randomness.
            static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());
            // ******************************************
    
            private const int IntArrayLength = 20;
            static readonly int[] ResultsArray = new int[IntArrayLength];
    
            public static Array GenerateRandomArray()
            {
                var randomNumberArray = new int[IntArrayLength];
                
                var popcounter = 0;
                while (popcounter < IntArrayLength)
                {
                    randomNumberArray[popcounter] = Random.Next(0, 10);
                    popcounter += 1;
                }
                return randomNumberArray;
            }
    
            public static void SearchForSevens()
            {
                var counter = 0;
                var randomArray = (int[])GenerateRandomArray();
                while (counter < IntArrayLength)
                {
                    if (randomArray[counter] == 7)
                    {
                        ResultsArray[counter] += 1;
                        counter = IntArrayLength;
                    }
                    counter += 1;
                }
            }
            static void Main()
            {
                var searchCounter = 0;
                while (searchCounter < 1000)
                {
                    SearchForSevens();
                    searchCounter += 1;
                }
    
                var displayCounter = 0;
                while (displayCounter < IntArrayLength)
                {
                    Console.WriteLine("Number of first occurrence of 7 at position {0} = {1}", displayCounter, ResultsArray[displayCounter]);
                    displayCounter += 1;
                }
                Console.ReadLine();
    
            }
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            //Step 1. Get the no of random numbers (n) to be generated from user. 
            Console.WriteLine("Enter the no of Random numbers: ");
            int n = int.Parse(Console.ReadLine());  
            //Step 2. Generate 'n' no of random numbers with values rangeing from 0 to 9 and save them in an array.
            Random rand = new Random();
            int[] randCollection = new int[n];  
            for (int i = 0; i < n; i++)
            {
               randCollection[i] = rand.Next(9);
               Console.WriteLine("Random No {0} = {1}", i + 1, randCollection[i]); 
            }
            //Step 3. Compute Average
            double average = randCollection.Average();
            Console.WriteLine("Average = {0}", average); 
            //Step 4. Find out how many numbers in the array are greated than the average. 
            int count = 0; 
            foreach(int i in randCollection){
                if (i > average) count++; 
            }
            Console.WriteLine("No of random numbers above their average = {0}", count);
            Console.ReadLine(); 
        }
    }

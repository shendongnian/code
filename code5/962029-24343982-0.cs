     public class Class1
    {
        private static int elementsCount = 500;
        private static int threadsCount = 20;
        private static string outputFileName = "defaultFileName.txt";
        private static bool isInQuietMode = false;
        private static BigRational totalSum = new BigRational(0.0m);
        private static CountdownEvent countDown = new CountdownEvent(1);
        public static void Main1(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Task<BigRational>> tasks = new List<Task<BigRational>>();
            //Create the tasks
            for (int threadIndex = 0; threadIndex < threadsCount; threadIndex++)
            {
                Task<BigRational> task = new Task<BigRational>(()=>
                {
                    return CalculateEulerNumber(threadIndex);
                    
                });
                tasks.Add(task);
            }
            foreach (var task in tasks)
            {
                task.Start();
            }
            //Wait for tasks
            Task.WaitAll(tasks.ToArray());
            //Add the results
            foreach (var task in tasks)
            {
                totalSum = BigRational.Add(totalSum, task.Result); 
            }
            File.WriteAllText(outputFileName, "Euler's number: " + totalSum);
            stopwatch.Stop();
            Console.WriteLine("Result: ");
            Console.WriteLine("Total time elapsed - " + stopwatch.Elapsed);
            if (!isInQuietMode)
            {
                Console.WriteLine("Euler's number - " + totalSum);
            }
        }
        private static BigRational CalculateEulerNumber(object threadIndexObject)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int threadIndex = Convert.ToInt32(threadIndexObject);
            BigRational sum = new BigRational(0.0m);
            for (int k = threadIndex; k < elementsCount; k += threadsCount)
            {
                BigRational numerator = BigRational.Pow((3 * k), 2) + 1;
                BigRational denominator = Factorial(3 * k);
               sum += BigRational.Divide(numerator, denominator);
            }
            stopwatch.Stop();
             int threadNumber = threadIndex + 1;
               Console.WriteLine("Тhread " + threadNumber + ": ");
               Console.WriteLine("Time elapsed - " + stopwatch.Elapsed);
                if (!isInQuietMode)
                {
                    Console.WriteLine("Intermediate sum - " + sum.ToString());
                }
               Console.WriteLine();
            return sum;
        }
        private static BigRational Factorial(int n)
        {
            BigRational factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }

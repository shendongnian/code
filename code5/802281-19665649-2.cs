        static void Main(string[] args)
        {
            List<int> inputList = AskUserForInput();
            PrintSum(inputList);
            PrintAverage(inputList);
            Console.ReadLine();
        }
        private static List<int> AskUserForInput()
        {
            List<int> inputList = new List<int>();
            do
            {
                Console.Write("Enter your number: ");
                int numberToAdd = Convert.ToInt32(Console.ReadLine());
                if (IsGreaterThan100(numberToAdd, inputList))
                {
                    Console.WriteLine("Number will not be added, {0} is greater than 100", numberToAdd + inputList.Sum());
                }
                else
                {
                    inputList.Add(numberToAdd);
                }
            } while (IsSumLowerThan100(inputList));
            return inputList;
        }
        private static bool IsGreaterThan100(int numberToAdd, List<int> inputList)
        {
            return numberToAdd + inputList.Sum() > 100;
        }
        private static bool IsSumLowerThan100(List<int> inputList)
        {
            return inputList.Sum() < 100;
        }
        private static void PrintAverage(List<int> inputList)
        {
            double avg = inputList.Sum() / inputList.Count;
            Console.WriteLine("The average is " + avg);
        }
        private static void PrintSum(List<int> inputList)
        {
            double sum = inputList.Sum();
            Console.WriteLine("The sum is " + sum);
        }
    }

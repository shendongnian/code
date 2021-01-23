    static void Main(string[] args)
    {
        List<int> inputList = new List<int>();
    
        do
        {
            Console.Write("Enter your number: ");
            int numberToAdd = Convert.ToInt32(Console.ReadLine());
    
            if (numberToAdd + inputList.Sum() > 100)
            {
                Console.WriteLine("Number will not be added, {0} is greater than 100", numberToAdd + inputList.Sum());
            }
            else
            {
                inputList.Add(numberToAdd);
            }
    
        } while (inputList.Sum() < 100);
    
        double sum = inputList.Sum();
        Console.WriteLine("The sum is " + sum);
    
        double avg = sum / inputList.Count;
        Console.WriteLine("The average is " + avg);
    
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        List<double> myList = new List<double>();
        var sum = 0;
        do
        {
            Console.Write("Enter your number: ");
            myList.Add(Convert.ToDouble(Console.ReadLine()));
            sum = myList.Sum();
            if (sum > 100)
            {
                Console.Write("Your sum is greater than 100.");
            }
        } while (sum <= 100)
        Console.WriteLine("The sum is " + sum);
 
        double avg = sum / myList.Count;
        Console.WriteLine("The average is " + avg);
    }

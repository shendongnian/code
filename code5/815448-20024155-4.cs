    class FibonacciSeries
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a num till which you want fibonacci series : ");
            int val = Convert.ToInt32(Console.ReadLine());
            int num1, num2;
            num1 = num2 = 1;
            Console.WriteLine(num1);
            if (val > num2)
            {
                while (num2 < val)
                {
                    Console.WriteLine(num2);
                    num2 += num1;
                    num1 = num2 - num1;
                }
            }
            Console.ReadLine();
        }
    }

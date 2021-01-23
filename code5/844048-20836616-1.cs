    class Program
    {
        static void Main(string[] args)
        {
            string [] numbers = {"1.5", "2$ 3", "12 3"};
            CalcTest cTest = new CalcTest();
            string[] result = cTest.uniform(numbers);
 
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }    

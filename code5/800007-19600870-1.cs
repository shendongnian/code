    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var lottery_numbers = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                //Asking for user input
                Console.WriteLine("How many number's you want to display?? ");
                // getting input from user
                int number = Convert.ToInt32(Console.ReadLine());
                // loop through the number user gave as input
                for (var i = 0; i < number; i++)
                {
                    Console.WriteLine("{0}", lottery_numbers[i]);
                }
                Console.Read();
            }
        }
    }

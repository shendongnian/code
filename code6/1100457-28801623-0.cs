    public class Multiplication
    {
        public static void Main(string[] args)
        {
            int value = 1;
            while (true)
            {
                if (value == -1)
                {
                    break;
                }
                else
                    {
                        Random randomNumbers = new Random(); // random number generator
                        int num01 = randomNumbers.Next(1, 11);
                        int num02 = randomNumbers.Next(1, 11);
                        Console.Write("Please enter the answer to {0} x {1} = ?", num01, num02);
                        int product = num01 * num02;
                        Console.WriteLine();
                        int answer = Convert.ToInt32(Console.ReadLine());
    
                        while (product != answer)
                        {
                            Console.WriteLine("Incorrect, enter another guess: ");
                            answer = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Correct. Your answer was {0} \n {1} x {2} = {3} Very good!",
                            answer, num01, num02, product);
                        //keep console open
                        Console.WriteLine();
                        Console.WriteLine("Press - 1 to exit or 1 to continue");
                        value = Convert.ToInt32(Console.ReadLine());
                    }
            }
        }
    }

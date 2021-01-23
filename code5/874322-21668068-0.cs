    class Program
    {
        private static void Main(string[] args)
        {
            const int from = 1;
            const int to = 50;
            int randomNumber = 50;
            int enteredNumber;
            Console.Write("The number is between 1 and 50.", from, to);
            while (true)
            {
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out enteredNumber))
                {
                    if (enteredNumber <= randomNumber)
                    {
                        Console.WriteLine("You entered a number between 1 & 50. Hit 'Enter' play again or enter 'Quit' to exit");
                        var answer = Console.ReadLine();
                        if (answer.ToLower() == "quit")
                        {
                            break;
                        }
                    }
                    else if (enteredNumber > randomNumber)
                    {
                        Console.WriteLine("You didn't enter a number between 1 & 50. Hit 'Enter' play again or enter 'Quit' to exit");
                        var answer = Console.ReadLine();
                        if (answer.ToLower() == "quit")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You didn't enter a number between 1 & 50. Hit 'Enter' play again or enter 'Quit' to exit");
                    var answer = Console.ReadLine();
                    if (answer.ToLower() == "quit")
                    {
                        break;
                    }
                }
            }
        }
    }

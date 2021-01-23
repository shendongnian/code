    public static string GetString(string prompt)
        {
            var input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                // you may also want to do other input validations here
                Console.WriteLine("Invalid entry - try again.");
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            return input;
        }

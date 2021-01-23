    class UserInput
    {
        public static bool GetBool(string prompt)
        {
            bool result;
            List<string> validTrueResponses = 
                new List<string> {"yes", "y", "true", "t", "affirmative", 
                    "ok", "okay", "yea", "yeah", "yep"};
            List<string> validFalseResponses = 
                new List<string> {"no", "n", "false", "f", "negative", 
                    "never", "not", "nay", "nix"};
            while (true)
            {
                if (prompt != null) Console.Write(prompt);
                var input = Console.ReadLine();
                if (validTrueResponses.Any(r => 
                    r.Equals(input, StringComparison.OrdinalIgnoreCase))) return true;
                if (validFalseResponses.Any(r => 
                    r.Equals(input, StringComparison.OrdinalIgnoreCase))) return false;
                if (bool.TryParse(input, out result)) break;
                Console.WriteLine("Sorry, I don't understand that response. " +
                    "Please try again.");
            }
            return result;
        }
        public static string GetString(string prompt)
        {
            if (prompt != null) Console.Write(prompt);
            return Console.ReadLine();
        }
        public static int GetInt(string prompt)
        {
            int input;
            while (true)
            {
                if (prompt != null) Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out input)) break;
                Console.WriteLine("Sorry, that is not valid. Please try again.");
            }
            return input;
        }
        public static decimal GetDecimal(string prompt)
        {
            decimal input;
            while (true)
            {
                if (prompt != null) Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out input)) break;
                Console.WriteLine("Sorry, that is not valid. Please try again.");
            }
            return input;
        }
    }

        private const string DIGITS = "0123456789";
    
        static void Main(string[] args)
        {
            Console.WriteLine(NextValue("8"));
            Console.ReadKey();
        }
        private static int NextValue(string value)
        {
            char nextChar = '\0';
            if(!string.IsNullOrEmpty(value))
            {
                char lastChar = value[value.Length - 1];
                int nextCharIndex = DIGITS.IndexOf(lastChar) + 1;
                if (nextCharIndex > DIGITS.Length)
                    nextChar = DIGITS[0];
                else
                    nextChar = DIGITS[nextCharIndex];
            }
            return int.Parse(nextChar.ToString());
        }

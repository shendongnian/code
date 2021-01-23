        private static unsafe int HowManyLeadingSpaces(string input)
        {
            if (input == null)
                return 0;
            if (input.Length == 0)
                return 0;
            if (string.IsNullOrWhiteSpace(input))
                return input.Length;
            int count = 0;
            fixed (char* unsafeChar = input)
            {
                
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsWhiteSpace((char)(*(unsafeChar + i))))
                        count++;
                    else
                        break;
                }
            }
            return count;           
                
        }

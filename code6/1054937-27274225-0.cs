    using System;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                string test = "thisIsTheStringToCheck!";
                bool anyInvalidChars = !test.All(isValidChar);
                Console.WriteLine(anyInvalidChars); // Prints True due to the "!" in the string.
            }
            private static bool isValidChar(char ch)
            {
                if ('A' <= ch && ch <= 'Z')
                    return true;
                if ('a' <= ch && ch <= 'z')
                    return true;
                switch (ch)
                {
                    case '&':
                    case '$':
                    case '.':
                    case ',':
                    // Add more cases as required.
                    {
                        return true;
                    }
                    default:
                    {
                        return false;
                    }
                }
            }
        }
    }

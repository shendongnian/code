    using System;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                CharValidator validator = new CharValidator();
                validator.AddValidAsciiRange('A', 'Z');
                validator.AddValidAsciiRange('a', 'z');
                validator.AddValidAsciiChar('&');
                validator.AddValidAsciiChar('$');
                validator.AddValidAsciiChar('.');
                validator.AddValidAsciiChar(',');
                string test = "thisIsTheStringToCheck!";
                bool anyInvalidChars = !validator.IsValidString(test);
                Console.WriteLine(anyInvalidChars); // Prints True due to the "!" in the string.
            }
        }
        public sealed class CharValidator
        {
            public void AddValidAsciiRange(char start, char end)
            {
                for (char ch = start; ch <= end; ++ch)
                    AddValidAsciiChar(ch);
            }
            public void AddValidAsciiChar(char ch)
            {
                if (ch >= 0 && ch <= 127)
                    _validAsciiChars[ch] = true;
            }
            public bool IsValidString(string str)
            {
                return str.All(IsValidChar);
            }
            public bool IsValidChar(char ch)
            {
                if (ch < 0 || ch >= 128)
                    return false;
                return _validAsciiChars[ch];
            }
            private readonly bool[] _validAsciiChars = new bool[128];
        }
    }

        static void Main(string[] args)
        {
            string intialString = "abc".ToUpper();
            string numberString = "";
            foreach (char c in intialString)
            {
                numberString += (int)c - 64;
            }
            Console.WriteLine(numberString);
        }

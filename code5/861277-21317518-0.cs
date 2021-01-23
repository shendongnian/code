        public void RecognizeOnlyLettersInString()
        {
            string name = "test the 123 thing";
            Console.WriteLine(name);
            string letters = "abcdefghijklmnopqrstuvwxyz";
            foreach (char c in name)
            {
                foreach(char letter in letters)
                {
                    if (c != letter)
                    {
                        Console.WriteLine("{0} is not a letter", c);
                        break;
                    }
                }
            }
        }

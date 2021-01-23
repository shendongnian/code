        public void RecognizeOnlyLettersInString()
        {
            string name = "test the 123 thing";
            Console.WriteLine(name);
            string letters = "abcdefghijklmnopqrstuvwxyz";
            foreach (char c in name)
            {
                foreach(char letter in letters)
                {
                    if (c == letter)
                    {
                        break;
                    }
                    if (letters.IndexOf(letter) == letters.Count() - 1)
                    {
                        Console.WriteLine("{0} is not a letter", c);
                    }
                }
            }
        }

    Random rnd = new Random();
    private string Generate_Name(int length)
        {
            
            string name = "";
            string[] letters = new string[21] { "b", "c", "d",
                                                    "f", "g", "h", "j",
                                                    "k", "l", "m", "n",
                                                    "p", "q", "r", "s", "t",
                                                    "v", "w", "x", "y", "z"};
            string[] vowels = new string[5] { "a", "e", "i", "o", "u" };
            for (int i = 0; i < length; i++)
            {
                if (i == 2 || i == 4)
                {
                    int index = rnd.Next(0, vowels.Length);
                    name += vowels[index];
                }
                else
                {
                    int index = rnd.Next(0, letters.Length);
                    name += letters[index];
                }
            }
            return name;
        }

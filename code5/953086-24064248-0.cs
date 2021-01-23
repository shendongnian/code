    static Random rnd = new Random();
    static void Main(string[] args)
    {
        string wrong = "";
        List<String> list = new List<String>();
        list.Add("Dune");
        list.Add("The Lord of the Rings");
        list.Add("The Iliad");
        list.Add("Hamlet");
        int r = rnd.Next(list.Count);
        Console.WriteLine((string)list[r]);
        string s = (string)list[r];
        string patten = "[a-zA-Z0-9]";
        Regex rgx = new Regex(patten);
        string sDash = rgx.Replace(s, "-");
        StringBuilder wrongAnswers = new StringBuilder();
        do
        {
            string a = " ";
            Console.Write("Guess a letter: ");
            a = Console.ReadLine();
            while (a.Length != 1)
            {
                Console.WriteLine("Please enter only one letter:");
                a = Console.ReadLine();
            }
            char myChar = a.ToLower()[0];
            int input = s.ToLower().IndexOf(myChar);
            bool foundSomething = false;
            StringBuilder builder = new StringBuilder(sDash);
            while(input != -1)
            {
                foundSomething = true;
                builder[input] = myChar;
                try
                {
                    input = s.ToLower().IndexOf(myChar, input + 1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    input = -1;
                }
            }
            sDash = builder.ToString();
            if (foundSomething)
            {
                Console.WriteLine(sDash + " " + sDash.ToLower().Equals(s.ToLower()));
            }
            else
            {
                wrongAnswers.Append(myChar);
                Console.WriteLine("Wrong, try again. \n {0}", wrongAnswers);
            }
        } while (!sDash.ToLower().Equals(s.ToLower()));
    }

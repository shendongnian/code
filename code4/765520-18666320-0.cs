        static void Main(string[] args)
        {
            Random cRandom = new Random(DateTime.Now.Millisecond);
            string answer = "";
            int length = Convert.ToInt32(6);
            int rndCap;
            int rndLetter;
            for (int i = 1; i <= length; i++)
            {
                rndCap = cRandom.Next(1, 3);
                rndLetter = cRandom.Next(0, 26);
                char tempMem = (char)('a' + rndLetter);
                string c2 = tempMem.ToString();
                if (rndCap == 2)
                {
                   c2 = tempMem.ToString().ToUpper();
                }
                answer = answer + c2;
            }
            Console.WriteLine(answer);
            Console.ReadLine();
        }

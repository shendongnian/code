     static void Main(string[] args)
        {
            string sentence = "Thats the sentence";
            string[] operands = Regex.Split(sentence,@" ");
            foreach(string i in operands)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

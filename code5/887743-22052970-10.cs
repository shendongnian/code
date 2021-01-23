    namespace Hangman
    {
        class Program
        {
        static void Main(string[] args)
        {
            string word;
            char letter_inserterd;
            int correctanswer = 5;
            int counter = 0;
            Console.WriteLine("welcome to the game of hangman");
            Console.Write("First player enter the secret word: ");
            word = Console.ReadLine();
            Char[] sentenceChar = word.ToCharArray();
            Console.WriteLine("Second player you can already play.");
            foreach( char letter in sentenceChar)
            {
                Console.Write(" _ "); 
            }
            Console.WriteLine("\n");
            Console.WriteLine("{0} correct answers are allowed. \n",correctanswer); //lives
            Char[] correctletter = new Char[sentenceChar.Length];
            for (int i = 0; i <sentenceChar.Length; i++)
            {
                correctletter[i] = '_'; 
            }
            while (correctanswer > 0)
            {
                Console.Write("\n\nWhat letter you want to play : ");
                letter_inserted = Convert.ToChar(Console.ReadLine());
                bool ContainsWord = false;
                for (int j = 0; j < sentenceChar.Length; j++)
                {
                    if (sentnceChar[j] == letter_inserted)
                    {
                        correctletter[j] = letter_inserted; //inserting the correct word
                        ContainsWord = true;
                    }
                }       
                if (!ContainsWord)
                {
                  correctanswer -= 1;
                }
                printWord(correctletter);
            }
        Console.ReadKey();
        }
        public static void printWord(char[] correctletter)
        {
            for (int j = 0; j < correctletter.Length; j++)
            {
                Console.Write(correctletter[j]);
            }
        }
    }
    }

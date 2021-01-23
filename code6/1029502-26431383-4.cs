    class Program 
    { 
        public static Random random = new Random(); 
        static void Main(string[] args) 
        {
            int[] randCombination = new int[4];
            for (int i = 0; i < 4; i++)
            {
                randCombination[i] = random.Next(0, 10);
                Console.Write(randCombination[i].ToString());
            }
            bool CodeCorrect = false;
         
            Console.WriteLine("\nYou have 12 guesses before you will be permenantly locked out.\n");
            int AmountOfGuesses = 0;
            while(AmountOfGuesses < 12 && !CodeCorrect)
            {
                Console.WriteLine("Enter 4 digit code to unlock the safe: ");
                int[] UserCode = new int[4];
                string input = Console.ReadLine();
                
                int n;
                bool isNumeric = int.TryParse(input, out n);
                
                int correctCount = 0;
                if(input.Length != 4 || !isNumeric)
                {
                    Console.WriteLine("Error. Input code was not a 4 digit number.\n");
                }
                else 
                {
                    for(int i = 0; i < 4; i++)
                    {
                        UserCode[i] = Convert.ToInt32(input[i]) - 48;
                        if(UserCode[i] == randCombination[i])
                        {
                            Console.WriteLine("The digit at position " + (i + 1) + " is correct.");
                            correctCount++;
                        }
                    }
                    if(correctCount == 4)
                    {
                        CodeCorrect = true;
                        Console.WriteLine("Code Correct. Safe unlocked.");
                    }
                }
                AmountOfGuesses++;
            }
            if(AmountOfGuesses > 12)
            {
                Console.WriteLine("Code Incorrect. Safe Locked permenantly.");
            }
            Console.ReadLine();
        }
    }

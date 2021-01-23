    using System;
    
    namespace ConsoleApplication
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                char[] letter = new char[26]
                {
                    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                    'V', 'W', 'X', 'Y', 'Z'
                };
                int letter_number = 0;
    
                //array of strings
                string[] diamond = new string[52];
                //get the letter
                Console.WriteLine("User enters a Letter between A and Z ");
                char user_letter = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                //search for letter number in the array letter
                for (int i = 0; i < letter.Length; i++)
                {
                    if (letter[i] == user_letter)
                    {
                        letter_number = i;
                        break;
                    }
                }
    
                //construct diamond 
    
                for (int i = 0; i <= letter_number; i++)
                {
                    //add initial spaces
                    for (int j = 0; j < letter_number - i; j++)
                    {
                        diamond[i] += " ";
                    }
    
                    //add letter (first time)
                    diamond[i] += letter[i];
    
                    //add space between letters
                    if (letter[i] != 'A')
                    {
                        for (int j = 0; j < 2*i - 1; j++)
                        {
                            diamond[i] += " ";
                        }
                        //add letter (second time)
                        diamond[i] += letter[i];
                    }
                    // Draw the first part of the diamond as it's composing.
                    Console.WriteLine(diamond[i]);
                }
    
                for (int i = letter_number - 1; i >= 0; i--)
                {
                    // Draw the second part of the diamond
                    // Writing the diamondArray in reverse order.
                    Console.WriteLine(diamond[i]);
                }
    
                // Mark a pause
                Console.ReadKey();
            }
        }
    }

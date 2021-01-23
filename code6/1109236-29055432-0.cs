    using System;
    public class vowelConsonant
    {
        public static void Main()
        {
            // Infinite loop.
            while (true)
            {
                int vowels = 0;
                int consonant = 0;
                int space = 0;
    
                Console.WriteLine("Enter a Sentence or a Character");
                string v = Console.ReadLine().ToLower();
    
                for (int i = 0; i < v.Length; i++)
                {
                    if (v[i] == 'a' || v[i] == 'e' || v[i] == 'i' || v[i] == 'o' || v[i] == 'u')
                    {
                        vowels++;
                    }
    
                    else if (char.IsWhiteSpace(v[i]))
    
                    {
                        space++;
                    }
    
                    else
                    {
                        consonant++;
                    }
                }
    
                Console.WriteLine("Your total number of vowels is: {0}", vowels);
                Console.WriteLine("Your total number of constant is: {0}", consonant);
                Console.WriteLine("Your total number of space is: {0}", space);
            }
        }
    }

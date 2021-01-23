    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace WordPerms
    {
        class Program
        {
            Stack<char> chars = new Stack<char>();
            List<string> words = new List<string>();
    
            static void Main(string[] args)
            {
                Program p = new Program();
                p.GetChar("abad");
    
                foreach (string word in p.words)
                {
                    Console.WriteLine(word);
                }
            }
    
    // This is called recursively to build the list of words.
    private void GetChar(string alpha)
            {
                string beta;
    
                for (int i = 0; i < alpha.Length; i++)
                {
                    chars.Push(alpha[i]);
                    beta = alpha.Remove(i, 1);
                    GetChar(beta);
                }
    
                char[] charArray = chars.Reverse().ToArray();
                words.Add(new string(charArray));
                
                if (chars.Count() >= 1)
                {
                    chars.Pop();
                }
            }
        }
    }

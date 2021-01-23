    using System;
    using System.Collections.Generic;
    
    namespace ParseParentheses
    {
        class Program
        {
            static List<string> wordList = new List<string>();
            static int wordIndex = -1;
            
        static void Main(string[] args)
        {
            GetChunks("(true AND (true OR false)) OR ((true AND false) OR false)");
            // Now we know how many items we have, convert the List to an array,
            // as this is what the solution specified.
            string[] words = wordList.ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(i + ":\t" + words[i]);
            }
        }
        private static void GetChunks(string text)
        {
            int start;
            int end = text.IndexOf(')');
            if (end > -1)
            {
                start = text.LastIndexOf('(', end - 1);
                if (start == -1)
                {
                    throw new ArgumentException("Mismatched parentheses", text);
                }
                wordList.Add(text.Substring(start, end - start + 1));
                wordIndex++;
                text = text.Substring(0, start)
                    + wordIndex.ToString()
                    + text.Substring(end + 1);
                GetChunks(text);
            }
            else
            {
            // no more ) in text, just add what's left to the List.
                wordList.Add(text);
            }
        }
      }
    }

    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
        const string t1 = "To be or not to be, that is the question.";
        Console.WriteLine(WordCounting.CountWords1(t1));
    
        const string t2 = "Mary had a little lamb.";
        Console.WriteLine(WordCounting.CountWords1(t2));
        }
    }
    
    /// <summary>
    /// Contains methods for counting words.
    /// </summary>
    public static class WordCounting
    {
        /// <summary>
        /// Count words with Regex.
        /// </summary>
        public static int CountWords1(string s)
        {
            MatchCollection collection = Regex.Matches(s, @"[\S]+");
            return collection.Count;
        }
    }

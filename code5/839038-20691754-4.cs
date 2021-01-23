    using System;
    using System.Collections.Generic;
    using System.Linq;
    class SortedSetDemo
    {
        static void Main(string[] args)
        {
            var words = new string[]
                {"the", "quick", "brown", "fox", "jumps",
                 "over", "the", "lazy", "dog"};
            // Create a sorted set.
            var wordSet = new SortedSet<string>();
            foreach (string word in words)
            {
                wordSet.Add(word);
            }
            // List the members of the sorted set.
            Console.WriteLine("Set items in sorted order:");
            int i = 0;
            foreach (string word in wordSet)
            {
                Console.WriteLine("{0}. {1}", i++, word);
            }
            // Access an item at a specified index (position).
            int index = 6;
            var member = wordSet.ElementAt(index);
            Console.WriteLine("\nThe item at index {0} is '{1}'!", index,
                              member);
        }
    }

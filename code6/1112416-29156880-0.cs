    namespace ConsoleApplication7
    {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var searchItems = new List<string> { "MS Excel documentation", "MS Excel tutorial", "MS Access documentation", "MS Access tutorial", "Google Chrome documentation", "Google Product video for Chrome" };
            var searchTerms = new List<string> { "google", "chrome" };
            var searchResults = searchItems.Where(a => searchTerms.All(b => a.IndexOf(b, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
            foreach (var searchResult in searchResults)
            {
                Console.WriteLine(searchResult);
            }
            Console.ReadLine();
        }
    }
    }

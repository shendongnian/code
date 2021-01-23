    string[] words = new string[5];
        foreach (string word in words) {
        
            Console.WriteLine("Type in a word");
            
            word = Console.ReadLine();
            
            var ordered = words.Where(w=>!String.IsNullOrEmpty(w)).OrderBy(w=>w.length)
            
            if (ordered.First() == word) 
                Console.Write("Shortest");
            if (ordered.Last() == word)
                Console.Write("Longest");
            
            // First time will display both "Shortest" and "Longest" since it's the only word.
            // You may adjust code depending on what do you want to do in case of words of same length.
            Console.ReadKey(true);
        }
    }

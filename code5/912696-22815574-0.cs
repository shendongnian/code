    var grouped = line.GroupBy(c=> c);
    		
    var vowels = grouped.Where(g => charArray.Contains(g.Key));
    var mostUsed = vowels.OrderBy(v => v.Count()).Last();
    		
    Console.WriteLine("Characters: {0}:", grouped.Count());
    Console.WriteLine("Vowels: {0}:", vowels.Count());
    Console.WriteLine("Most used vowel: {0} - {1}:", mostUsed.Key, mostUsed.Count());

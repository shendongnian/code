    Console.WriteLine("Enter your word");
    var word = Console.ReadLine();
    var vowelCount = word.Count("aeiouAEIOU".Contains);
    
    Console.WriteLine("Number of vowels equals " + vowelCount);

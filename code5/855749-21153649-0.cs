    string sentence = "This IS a SEntence";
    var wordCount = sentence.Split(new char[] { ' ' })
      .Where(word => word.Count(letter => char.IsUpper(letter)) == 2)
      .Count();
    Console.WriteLine(wordCount );
    Console.ReadKey();

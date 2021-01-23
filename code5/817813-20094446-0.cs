    userInput = Console.ReadLine();
    string[] wordbits = Regex.Split(userInput,@"\w+\s+\w+");
    foreach(var word in wordbits){
      var w = word.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      dict[w[0]] = w[1];
    }

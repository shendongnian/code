    userInput = Console.ReadLine();
    var matches = Regex.Matches(userInput,@"\w+\s+\w+");
    foreach(Match m in matches){
      if(m.Success){
        var w = m.Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        dict[w[0]] = w[1];
      }
    }

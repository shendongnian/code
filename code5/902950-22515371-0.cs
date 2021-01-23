    var userInput = Console.ReadLine();
    if(userInput.Length == 2)
    {
        var words = data.Split(userInput[0]).Where(x => x.StartsWith(userInput[1].ToString()));
    
        if(words.Any())
        {
           var result = words.Select(x => x.Substring(1)).ToList();
        }
        else 
        {
           // no word found
        }
    }
  

    List<string> inputs = new List<string>();
    var endInput = false;
    while(!endInput)
    {
       var currentInput = Console.ReadLine();
       if(String.IsNullOrWhitespace(currentInput))
       {
           endInput = true;
       }
       else
       {
            inputs.Add(currentInput);
       }
    }
    
    // when code continues here you have all the user's input in separate entries in "inputs"

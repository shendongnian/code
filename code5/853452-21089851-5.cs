    var valuesToCheck = new Dictionary<int, string> {
        { 3, "Fizz" },
        { 5, "Buzz" }
    };
    
    for (int i = 1; i <= value; i++)
    {
         bool divisorFound = false;
    
         foreach(var kvp in valuesToCheck)
         {
             if (i % kvp.Key == 0)
             {
                 divisorFound = true;
                 ViewBag.Output += kvp.Value + " ";
             }
         }
    
         if (!divisorFound)
             ViewBag.Output += i + " ";
    }

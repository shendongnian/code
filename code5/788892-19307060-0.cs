    Regex RX = new Regex(@"counterparty=""([^""]*)"" (.*?\n){3}product=""12345""",
           RegexOptions.Singleline | RegexOptions.IgnoreCase);
    Match M = RX.Match(YourString);
            
    if (M.Success)
         strCounterParty = M.Result("${1}");  //Returns the value between the 1st set of ()'s

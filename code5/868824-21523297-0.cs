    if(match.Success)
    {
       for(int i = 0; i< match.Groups["price"].Captures.Count;i++)
       {
                string key = match.Groups[1].Value;
    
                Console.WriteLine(key);
       }
    }

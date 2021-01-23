    if(match.Success)
    {
       for(int i = 0; i< match.Groups["price"].Captures.Count;i++)
       {
                string key = match.Groups["price"].Value;
    
                Console.WriteLine(key);
       }
    }

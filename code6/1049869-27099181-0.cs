    List<string> fnColArr = new List<string>() 
    { "Punctuation", "period", "Space", "and", "yes" };
    
                foreach (string item in fnColArr)
                {
                    if (item.IndexOf("puNctuation", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine("match");
                        
                    }
                }

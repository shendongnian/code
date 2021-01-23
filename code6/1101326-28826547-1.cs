     var strings = new string[]
                {"'Name'+Code '+ On +'Sector'", 
                 "'Name + R405' + '(Name)'",
                 "'Name + Code' + On + 'Sector'",
                 "'Name''+'Sector'"
                };
    
                const string pattern = @"(?<=')(\s*\+\s*|\s*\+\s*On\s*\+\s*)(?=')";
    
                foreach (string s in strings)
                {
                    Console.WriteLine("input:"+s);
                    string[] tokens = Regex.Split(s, pattern);
                    foreach (string token in tokens)
                    {
                        Console.WriteLine("token:->{0}<-", token);
                    }                    
                    //tokens.Where((x, i) => i % 2 == 0)  //single quoted strings
                    //tokens.Where((x, i) => i % 2 != 0) //glue sequences
                }

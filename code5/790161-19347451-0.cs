    Dictionary<int, Dictionary<string, string>> answers = new Dictionary<int, Dictionary<string, string>>()
                {
                    {1,new Dictionary<string,string>()
                           {
                               {"a","Wenen"},{"b","Rome"},
                               {"c","Kiev"},{"correct","a"}
                           }},
                     {2,new Dictionary<string,string>()
                           {
                               {"a","De Mount-everest"},{"b","De Kilimanjaro"},
                               {"c","De Aconcagua"},{"correct","b"}
                           }},
                      {3,new Dictionary<string,string>()
                           {
                               {"a","Thomas Edison"},{"b","Albert Einstein"},
                               {"c","Abraham Lincoln"},{"correct","a"}
                           }}
                };
                List<string> quiz = new List<string>()
                {
                    "Wat is de hoofstad van Oostenrijk?",
                    "Hoe heet de hoogste berg van Afrika?",
                    "Wie was de uitvinder van de gloeilamp?"
                };           
                
                bool IsDone = false;
                int question = 1;
                while (!IsDone)
                {
                    Console.WriteLine(question + "º: Vraag 1:");
                    Console.WriteLine();
                    Console.WriteLine(quiz[question - 1]);
                    Console.WriteLine();
                    Console.Read();
                    Console.WriteLine(string.Format("a: {0} b: {1} c: {2}", answers[question]["a"], answers[question]["b"], answers[question]["c"]));
                    Console.Read();
                    string entered1 = Console.ReadLine();
    
                    if (entered1.ToLower() == answers[question]["correct"])
                    {
                        ConsoleColor col = Console.ForegroundColor;
                        Console.ForegroundColor = (ConsoleColor.Green);
                        Console.WriteLine("Goedzo, op naar de volgende!");
                        Console.WriteLine("Continue playing?  [y] [n]");
                        if (Console.ReadLine() == "y")
                        {
                            question++;
                            Console.ForegroundColor = col;
                            continue;
                        }
                        else
                            IsDone = true;
                    }
                    else
                    {
                        Console.WriteLine("FOUT!");
                        Console.WriteLine("Continue playing?  [y] [n]");
                        if (Console.ReadLine() == "y")
                        {
                            question++;
                            continue;
                        }
                        else
                            IsDone = true;
                    }
    
                }

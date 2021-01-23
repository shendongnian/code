                        string pattern = @".*-\d{2}";
                        Match match = Regex.Match(arg, pattern);
                        Console.Write("{0} ", arg);
                        if (match.Success)
                        {
                            Console.WriteLine("Matched");
                        }
                        else
                        {
                            Console.WriteLine("did NOT Match");
                        }

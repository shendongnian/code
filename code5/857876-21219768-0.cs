    using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        if (line != null && line.Contains(":"))
                        {
                             line.Split('@')
                                  .Where(x => !x.Any(c => char.IsLetter(c)))
                                  .Select(x => x)
                                  .ToList()
                                  .ForEach( (ln) => Console.WriteLine(ln) );
                            
                        }
                    }
                }

    using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        if (line != null && line.Contains(":"))
                        {
                           line.Split(new [] { '@' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Where(x => !x.Any(c => char.IsLetter(c)))
                                  .ToList()
                                  .ForEach( (ln) => Console.WriteLine(ln) );
                            
                        }
                    }
                }

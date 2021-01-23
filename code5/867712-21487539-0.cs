    var doubles = text.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                  .Skip(1)
                  .Select(line => line.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries)
                                      .Select(x => double.Parse(x)).ToArray())
                  .ToArray();

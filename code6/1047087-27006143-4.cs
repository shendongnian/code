           foreach (var entry in entries)
            {
                try
                {
                    var tokens = entry.Split('$');
                    decimal amount;
                    if (tokens.Length > 1)
                        amount = decimal.Parse(tokens[1]);
                    else
                        throw new FormatException("invalid entry");
                    string nameSplit = entry.Split('.', ':')[1].Trim();
                    if (names.ContainsKey(nameSplit))
                    {
                        names[nameSplit] += amount;
                        Console.WriteLine("Hoozah!");
                    }
                    else
                    {
                        names.Add(nameSplit, amount);
                        Console.WriteLine("Failure");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(string.Format("Format exception for entry \"{0}\"", entry));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("{0} for entry \"{1}\"", ex.GetType().Name, entry));
                }
            }

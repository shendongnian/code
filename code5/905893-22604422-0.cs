    var result = str.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => !x.All(char.IsUpper) &&
                                !x.All(char.IsLower) &&
                                !(char.IsUpper(x[0]) &&
                                  x.Skip(1).All(char.IsLower)))
                    .ToArray();

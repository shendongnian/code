     var orderedList = test
                .OrderBy(x => new string(x.Where(char.IsLetter).ToArray()))
                .ThenBy(x =>
                {
                    int number;
                    if (int.TryParse(new string(x.Where(char.IsDigit).ToArray()), out number))
                        return number;
                    return -1;
                }).ToList();

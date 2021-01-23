      var makes = new List<string> {
                                           "Audi",
                                           "BMW",
                                           "Ford",
                                           "Vauxhall",
                                           "Volkswagen"
                                         }.GroupBy(t => t[0])
                    .Select(t => t.First()).ToList();

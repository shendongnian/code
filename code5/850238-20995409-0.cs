            List<List<string>> listOfList = new List<List<string>>()
            {
                new List<string>() { "Name 1", "1", "2"}, 
                new List<string>() { "Name 1", "3", "4"}, 
                new List<string>() { "Name 2", "1", "2"}  
            };
            var result = listOfList
                .GroupBy(grp => grp.First())
                .Select(grp => new List<string>{ grp.Key }.AsEnumerable().Concat(grp.SelectMany(g => g.Skip(1))).ToList())
                .ToList();

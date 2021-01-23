        var sentenceList = new List<string>(new String[] { "Gerald has a nice car", "Rachel has a cute cat" });
        var entityList = new HashSet<string>(new String[] { "Gerald", "car", "Rachel", "cat" });
        var a = sentenceList.Aggregate(new List<List<string>>(),
            (lst, str) =>
            { 
                lst.Add(str.Split(' ').Where(x => entityList.Contains(x)).ToList());
                return lst; 
            },
            x => x.Where(y => y.Count > 0).ToList());
